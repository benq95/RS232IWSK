using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace IWSK_RS232
{
    public partial class MainForm : Form
    {
        private RS232Port rsPort = new RS232Port();
        private Logger logger = new Logger();
        private DataFormat dataFormat = DataFormat.ASCII;
        private Parser parser = new Parser();
        Stopwatch pingWatch = new Stopwatch();
        List<byte> pingList = new List<byte>();
        List<byte> pongList = new List<byte>();
        byte[] pongArr = new byte[] { 80, 79, 78, 71 };
        byte[] pingArr = new byte[] { 80, 73, 78, 71 };
        bool connectedDuePing = false;
        private bool waitForResponse = false;
        private int waitForAddress = 0;
        private bool connected = false;
        
        public MainForm()
        {
            InitializeComponent();

            rsPort.Connected += rsPort_Connected;
            rsPort.Disconnected += rsPort_Disconnected;
            rsPort.DataReceived += rsPort_DataReceived;
            rsPort.DataSent += rsPort_DataSent;
            rsPort.TransactionFinished += (sender, e) => logger.LogMessage("Transakcja zakończona " + (e.TransactionResult ? "powodzeniem" : "niepowodzeniem"));
            rsPort.PinChanged += (sender, e) => UpdatePins();
            parser.FrameParsed += parser_FrameParsed;
            radioButton1.CheckedChanged += this.master_changed;
            radioButton2.CheckedChanged += this.slave_changed;
            radioButton3.CheckedChanged += this.customMessage_changed;
            numericUpDown3.ValueChanged += this.onFrameTimeoutChanged;

            this.panel1.Enabled = true;
            this.panel5.Enabled = false;
            this.panel2.Enabled = false;
            this.panel3.Enabled = false;
            this.button5.Enabled = false;

        }

        private void ReloadPorts()
        {
            portComboBox.DataSource = SerialPort.GetPortNames();

            if (portComboBox.Items.Count > 0)
            {
                portComboBox.SelectedIndex = 0;
                connectButton.Enabled = true;
            }
            else
            {
                logger.LogMessage("Nie odnaleziono portów COM w komputerze.");
                connectButton.Enabled = false | rsPort.IsOpen;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadPorts();

            bitCountComboBox.SelectedIndex = 1;
            stopBitComboBox.SelectedIndex = 0;
            parityComboBox.SelectedIndex = 0;
            flowControlComboBox.SelectedIndex = 0;
        }

        private void rescanPortsButton_Click(object sender, EventArgs e)
        {
            ReloadPorts();
        }

        #region Connection
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                rsPort.SetConnectionParameters(portComboBox.SelectedItem.ToString(),
                    Convert.ToInt32(baudRateComboBox.Text),
                    RS232Port.ParityArray(parityComboBox.SelectedIndex),
                    Convert.ToInt32(bitCountComboBox.SelectedItem),
                    RS232Port.StopBitsArray(stopBitComboBox.SelectedIndex));

                if (!rsPort.Connect())
                {
                    logger.LogMessage("Nie można otworzyć portu: " + rsPort.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage("Podano niepoprawne argumenty: " + ex.Message);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (!rsPort.Disconnect())
                logger.LogMessage("Nie można zamknąć portu.");
            
        }

        private void rsPort_Connected(object sender, EventArgs e)
        {
            connectButton.Text = "Rozłącz";
            connectButton.Click -= connectButton_Click;
            connectButton.Click += disconnectButton_Click;
            UpdatePins();
            rtsCheckBox.Checked = rsPort.RTSEnable;
            dtrCheckBox.Checked = rsPort.DTREnable;

            sendButton.Enabled = true;
            this.button5.Enabled = radioButton1.Checked ? true : false;
            connected = true;
        }


        private void rsPort_Disconnected(object sender, EventArgs e)
        {
            InvokeOrNot(() =>
            {
                connectButton.Text = "Połącz";
                connectButton.Click -= disconnectButton_Click;
                connectButton.Click += connectButton_Click;
            }, connectButton);
            InvokeOrNot(() => sendButton.Enabled = false, sendButton);
            this.button5.Enabled = false;
            connected = false;
        }
        #endregion Connection

        private void InvokeOrNot(Action f, Control ctrl)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(f);
            else
                f.Invoke();
        }

        private void rsPort_DataSent(object sender, SentEventArgs e)
        {
            if (!pingWatch.IsRunning)
            {
                if (radioButton3.Checked)
                {
                    InvokeOrNot(() => writeRawDataRichTextBox.AppendText(StringParser.ByteToDisplay(e.Buff, dataFormat)), writeRawDataRichTextBox);
                    return;
                }
                InvokeOrNot(() => richTextBox1.AppendText(StringParser.ByteToDisplay(e.Buff, DataFormat.ASCII) + " {" + StringParser.ByteToDisplay(e.Buff, DataFormat.HEX) + "}"), richTextBox1);
            }
        }

        private bool IsPongData()
        {
            for (int i = 0; i < pongArr.Length; i++)
            {
                if (pongList[i] != pongArr[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void TerminatePing(byte[] data)
        {
            foreach (var b in data)
            {
                pingList.Add(b);

                if (b == pingArr[pingList.Count - 1])
                {
                    if (pingList.Count == pingArr.Length)
                    {
                        rsPort.Send(pongArr, true);
                    }
                }
                else
                {
                    pingList.Clear();
                }
            }
        }

        private void rsPort_DataReceived(object sender, EventArgs e)
        {
            byte[] data = rsPort.GetReadBytes().ToArray();

            TerminatePing(data);

            if (pingWatch.IsRunning)
            {
                pongList.AddRange(data.Take(pongArr.Length - pongList.Count));

                if (pongList.Count == pongArr.Length)
                {
                    if (IsPongData())
                    {
                        logger.LogMessage("PING: " + pingWatch.Elapsed);
                        data = data.Skip(pongList.Count).Take(data.Length - pongList.Count).ToArray();
                    }
                    else
                    {
                        logger.LogMessage("PING: " + pingWatch.Elapsed + "\nNiepoprawne dane.");
                    }

                    PingStop();
                }
            }
            if (radioButton3.Checked)
            {
                if (!connectedDuePing)
                    InvokeOrNot(() =>
                    {
                        readRawDataRichTextBox.AppendText(StringParser.ByteToDisplay(data));
                        parser.AppendToParser(data);
                    }, readRawDataRichTextBox);
                return;
            }
            if (radioButton2.Checked)
            {

                if (!StringParser.CheckModbusMessage(data, (byte)numericUpDown5.Value))
                {
                    return;
                }
                if (data[4] == 50)
                {
                    this.SendMsg(2, (byte)numericUpDown5.Value);
                    return;
                }
            }
            if (radioButton1.Checked)
            {
                if (!StringParser.CheckModbusMessage(data, (byte)waitForAddress))
                {
                    return;
                }
                if (!waitForResponse)
                {
                    return;
                }
            }
            waitForResponse = false;
            waitForAddress = 0;
            InvokeOrNot(() =>
            {
                string msg = StringParser.ByteToDisplay(StringParser.GetModbusMessage(data), DataFormat.ASCII);
                richTextBox2.AppendText(msg);
                parser.AppendToParser(data);
            }, richTextBox2);

        }

        private void InitTransaction(int time)
        {
            if (rsPort.IsTransaction)
            {
                logger.LogMessage("Aktualnie wykonywana już jest transakcja, nie można wysłać danych jako transakcji.");
                return;
            }

            int interval;

            if (!int.TryParse(transactionTextBox.Text, out interval))
            {
                transactionTextBox.Text = (pingTimer.Interval = time).ToString();
            }
            if(!radioButton1.Checked)
            {
                interval = time;
            }
            rsPort.SetTransaction(interval);
        }


        private void send_Design(object sender, EventArgs e)
        {
            if (rsPort.IsOpen)
            {
                bool bug = false;

                if (textRadioButton.Checked)
                {
                    List<byte> sendByte = new List<byte>(StringParser.StrToByteArray(sendTextBox.Text));

                    if (parser.Terminator != null)
                    {
                        sendByte.AddRange(parser.Terminator);
                    }

                    if (!rsPort.Send(sendByte.ToArray()))
                    {
                        bug = true;
                        logger.LogMessage("Nie można wysłać danych: " + rsPort.ErrorMessage);
                    }
                    else
                    {
                        if (delTextCheckBox.Checked)
                            sendTextBox.Clear();
                    }
                }
                else 
                {
                    try
                    {
                        if (!rsPort.Send(File.ReadAllBytes(filePathTextBox.Text), true))
                            throw new Exception(rsPort.ErrorMessage);

                        readRawDataRichTextBox.AppendText("\n *** Wysłano plik " + filePathTextBox.Text + " *** \n");
                    }
                    catch (Exception ex)
                    {
                        logger.LogMessage("Nie można wysłać pliku " + filePathTextBox.Text + "\n" + ex.Message);
                        bug = true;
                    }
                }

                if (!bug && transactionCheckBox.Checked)
                {
                    InitTransaction(100);
                }
            }
        }

        private void parser_FrameParsed(object sender, EventArgs e)
        {
            InvokeOrNot(() => readFrameListBox.Items.Add(StringParser.ByteToDisplay(parser.Frame, dataFormat)), readFrameListBox);
        }

        private void sendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                send_Design(this, e);
            }
        }

        private void setTerminatorButton_Click(object sender, EventArgs e)
        {
            parser.Terminator = StringParser.StrToByteArray(terminatorTextBox.Text);
            logger.LogMessage("Ustawiono terminator: " + terminatorTextBox.Text);
        }

        private void pingButton_Click(object sender, EventArgs e)
        {
            if (!rsPort.IsOpen)
            {
                connectButton_Click(sender, e);
                connectedDuePing = true;
            }

            if (!rsPort.Send(pingArr, true))
            {
                logger.LogMessage("Nie można zrobić PING: nie można ustanowić połączenia.");
            }

            pingWatch.Start();
            int interval;

            if (int.TryParse(pingTimeOutTextBox.Text, out interval))
            {
                pingTimer.Interval = interval;
            }
            else 
            {
                pingTimeOutTextBox.Text = (pingTimer.Interval = 100).ToString();
            }
            pingTimer.Start();
            pingButton.Enabled = false;
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void PingStop(bool timeout = false)
        {
            pingTimer.Stop();

            if(timeout)
                logger.LogMessage("PING: Timeout");

            pingWatch.Stop();
            pongList.Clear();

            InvokeOrNot(() => pingButton.Enabled = true, pingButton);

            if (connectedDuePing)
            {
                disconnectButton_Click(null, null);
            }
        }

        private void pingTimer_Tick(object sender, EventArgs e)
        {
            PingStop(true);
        }

        private void crButton_Click(object sender, EventArgs e)
        {
            terminatorTextBox.Text += "\\r";
        }

        private void lfButton_Click(object sender, EventArgs e)
        {
            terminatorTextBox.Text += "\\n";
        }

        private void asciiReadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
                dataFormat = (DataFormat)Convert.ToInt32(rb.Tag);
        }

        private void dtrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rsPort.DTREnable = dtrCheckBox.Checked;
            }
            catch (NullReferenceException)
            {
                if(dtrCheckBox.Checked)
                    dtrCheckBox.Checked = false;
            }
        }

        private void rtsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rsPort.RTSEnable = rtsCheckBox.Checked;
            }
            catch (NullReferenceException)
            {
                if(rtsCheckBox.Checked)
                    rtsCheckBox.Checked = false;
            }
        }

        private void UpdatePins()
        {
            InvokeOrNot(() => dsrCheckBox.Checked = rsPort.DSR, dsrCheckBox);
            InvokeOrNot(() => ctsCheckBox.Checked = rsPort.CTS, ctsCheckBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rsPort.IsOpen)
            {
                bool bug = false;

                if (textRadioButton.Checked)
                {
                    List<byte> sendByte = new List<byte>(StringParser.StrToByteArray(sendTextBox.Text));

                    if (parser.Terminator != null)
                    {
                        sendByte.AddRange(parser.Terminator);
                    }

                    if (!rsPort.Send(sendByte.ToArray()))
                    {
                        bug = true;
                        logger.LogMessage("Nie można wysłać danych: " + rsPort.ErrorMessage);
                    }
                    else
                    {
                        if (delTextCheckBox.Checked)
                            sendTextBox.Clear();
                    }
                }

                if (!bug)
                {
                    InitTransaction(100);
                }
            }
        }

        private void customMessage_changed(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            {
                this.groupBox4.Enabled = false;
                this.groupBox1.Enabled = false;
                this.groupBox6.Enabled = false;
                this.panel1.Enabled = false;
                this.panel5.Enabled = true;
                RS232Port.modbusEnable = true;
                
            } else
            {
                this.groupBox4.Enabled = true;
                this.groupBox1.Enabled = true;
                this.groupBox6.Enabled = true;
                this.panel1.Enabled = true;
                this.panel5.Enabled = false;
                this.button5.Enabled = false;
                RS232Port.modbusEnable = false;
            }
        }

        private void master_changed(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                this.panel2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.panel2.Enabled = true;
                this.button5.Enabled = connected ? true : false;
                RS232Port.setFrameTimeout(this.numericUpDown3.Value > 0 ? (int)this.numericUpDown3.Value : 1);
            }
        }

        private void slave_changed(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                this.panel3.Enabled = false;
            }
            else
            {
                this.panel3.Enabled = true;
                RS232Port.setFrameTimeout(this.numericUpDown4.Value > 0 ? (int)this.numericUpDown4.Value : 1);
            }
        }


        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte instrNumber = (byte)numericUpDown6.Value;
            byte address = (byte)numericUpDown7.Value;
            if ((instrNumber == 2) && (address == 0))
            {
                logger.LogMessage("Rozkaz 2 nie może być użyty w trybie rozgłoszeniowym");
                return;
            }
            if(SendMsg(instrNumber, address))
            {
                if(instrNumber == 2)
                {
                    waitForAddress = address;
                    waitForResponse = true;
                }
            }
        }
        private bool SendMsg(byte instrNumber, byte address)
        {
            if (rsPort.IsOpen)
            {
                if ((instrNumber == 2) && (this.radioButton1.Checked))
                {
                    InitTransaction((int)(numericUpDown1.Value));
                }

                List<byte> sendByte = new List<byte>(System.Text.ASCIIEncoding.Default.GetBytes(StringParser.FormatMessageToModbus(textBox9.Text,instrNumber,address)));
                int i = -1;
                bool sent = rsPort.Send(sendByte.ToArray());
                for (i = 0; (!sent) || (i < numericUpDown2.Value); i++)
                {
                    sent = rsPort.Send(sendByte.ToArray());
                }
                if(!sent)
                {
                    logger.LogMessage("Nie można wysłać danych: " + rsPort.ErrorMessage);
                    return false;
                }
                
            }
            return true;
        }

        private void onFrameTimeoutChanged(object sender, EventArgs e)
        {
            if(rsPort != null)
            {
                if (radioButton1.Checked)
                {
                    RS232Port.setFrameTimeout(this.numericUpDown3.Value > 0 ? (int)this.numericUpDown3.Value : 1);
                } else
                {
                    RS232Port.setFrameTimeout(this.numericUpDown4.Value > 0 ? (int)this.numericUpDown4.Value : 1);
                }
                
            }
        }

        private void readFrameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void readRawDataRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
