using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;

namespace RS232_GUI
{
    public partial class Form1 : Form
    {

        private SerialPort serialPort = new SerialPort();
        byte[] pongArr = new byte[] { 80, 79, 78, 71 };
        byte[] pingArr = new byte[] { 80, 73, 78, 71 };
        private Timer timer = new Timer();
        private Timer frameTimer = new Timer();
        List<byte> buffer = new List<byte>();
        static volatile bool  isTransaction = false;
        static volatile bool pingWait = false;
        static volatile bool partFrame = false;
        static volatile bool terminatorReceived = true;
        static volatile byte[] terminator;
        int retransmisions = 0;
        byte[] lastSentMsg;
        static volatile bool mode = false;//false rs232 true modbus
        private static readonly System.Object lockThis = new System.Object();

        public Form1()
        {
            InitializeComponent();
            DisableConnectFunction();
            timer.Tick += this.Timer_Tick;
            TabControl.SelectedIndexChanged += this.OnTabChanged;
            frameTimer.Tick += FrameTimer_Tick;
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            if (partFrame)
            {
                frameTimer.Stop();
                buffer.Clear();
                partFrame = false;
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (isTransaction)
            {
                buffer.Clear();
                if (retransmisions > 0)
                {
                    retransmisions--;
                    //log retransmit;
                    StartTransaction(lastSentMsg);
                }
                else
                {
                    //log transaction failed;
                    if (pingWait)
                    {
                        LogMessage("Ping timeout");
                    }
                    else
                    {
                        LogMessage("Transakcja zakończona niepowodzeniem");
                    }
                    pingWait = false;
                    isTransaction = false;
                    retransmisions = 0;
                }
            }

        }

        public void DisableConnectFunction()
        {
            ReceiveTextPanelASCII.Enabled = false;
            ReceiveTextPanelFrame.Enabled = false;
            SendTextPanelFrame.Enabled = false;
            SendTextPanelASCII.Enabled = false;
            SendButton.Enabled = false;
            LogIpunt.Enabled = false;
            LogOutput.Enabled = false;
            PingButton.Enabled = false;
            TimePing.Enabled = false;

        }

        public void DisableSettingsFunction()
        {
            TabControl.Enabled = false;
        }

        public void EnableSettingsFunction()
        {
            TabControl.Enabled = true;
        }

        public void EnableConnectingFunction()
        {
            ReceiveTextPanelASCII.Enabled = true;
            ReceiveTextPanelFrame.Enabled = true;
            SendTextPanelFrame.Enabled = true;
            SendTextPanelASCII.Enabled = true;
            SendButton.Enabled = true;
            LogIpunt.Enabled = true;
            LogOutput.Enabled = true;
            PingButton.Enabled = true;
            TimePing.Enabled = true;

        }

        void SetControlEnum()
        {
            int index = SettingControlFlewComboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    serialPort.Handshake = Handshake.None;
                    break;
                case 1:
                    serialPort.Handshake = Handshake.RequestToSend;
                    break;
                case 2:
                    serialPort.Handshake = Handshake.XOnXOff;
                    break;
            }
        }

        private void ReloadPorts()
        {
            portComboBox.DataSource = SerialPort.GetPortNames();

            if (portComboBox.Items.Count > 0)
            {
                portComboBox.SelectedIndex = 0;
                ConnectButton.Enabled = true;
            }
            else
            {
                LogMessage("Nie odnaleziono portów COM w komputerze.");
                ConnectButton.Enabled = false;
            }
        }

        public void LogMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }

        private void OnDataReceived(object sender, EventArgs e)
        {
            lock (lockThis)
            {
                int bytes = serialPort.BytesToRead;
                byte[] buff = new byte[bytes];
                serialPort.Read(buff, 0, bytes);
                InvokeOrNot(() =>
                {
                    if (mode)
                    {
                        LogIpunt.AppendText("Odebrano wiadomość:\n" + StringParser.ByteToDisplay(buff, DataFormat.HEX) + " -> " + StringParser.ByteToDisplay(buff) + "\n");
                        return;
                    }
                    if(terminator == null)
                    {
                        LogIpunt.AppendText("Odebrano wiadomość:\n" + StringParser.ByteToDisplay(buff, DataFormat.HEX) + " -> " + StringParser.ByteToDisplay(buff) + "\n");
                        return;
                    }
                    if(terminator.Length == 0)
                    {
                        LogIpunt.AppendText("Odebrano wiadomość:\n" + StringParser.ByteToDisplay(buff, DataFormat.HEX) + " -> " + StringParser.ByteToDisplay(buff) + "\n");
                        return;
                    }
                    if(buffer.Count < terminator.Length)
                    {
                        terminatorReceived = false;
                        return;
                    }
                    
                    
                }, LogIpunt);
                frameTimer.Stop();
                partFrame = false;
                buffer.AddRange(buff);
                if (pingWait)
                {
                    if (buffer.Count < 4)
                    {
                        return;
                    }
                    else
                    {
                        if (IsPong(buffer.ToArray()))
                        {
                            pingWait = false;
                            isTransaction = false;
                            LogMessage("Ping sukces");
                            EndTransaction();
                            return;
                        }
                    }
                }
                if (IsPing(buff))
                {
                    this.sendMsg(pongArr);
                    buffer.Clear();
                    return;
                }
                if (!mode)
                {
                    if(terminatorReceived)
                    {
                        buffer.Clear();
                    }
                    return;
                }
                //tutaj modbus
                int beginIndex = buffer.FindIndex((byte x) => { return x == 58; });
                if (beginIndex == -1)
                {
                    buffer.Clear();
                    return;
                }
                for (int i = 0; i < beginIndex; i++)
                {
                    buffer.RemoveAt(0);
                }
                if (buffer.Count >= 3)
                {
                    if ((buffer[buffer.Count - 1] == 10) && (buffer[buffer.Count - 2] == 13))
                    {
                        if (!StringParser.CheckModbusMessage(buffer.ToArray(), (byte)numericUpDown7.Value))
                        {
                            buffer.Clear();
                            InvokeOrNot(() =>
                            {
                                LogIpunt.AppendText("Niepoprawna ramka\n");
                            }, LogIpunt);

                            return;
                        }
                    }
                    else
                    {
                        frameTimer.Interval = numericUpDown3.Value == 0 ? 1 : (int)numericUpDown3.Value;
                        partFrame = true;
                        frameTimer.Start();
                        return;
                    }
                }
                else
                {
                    frameTimer.Interval = numericUpDown3.Value == 0 ? 1 : (int)numericUpDown3.Value;
                    partFrame = true;
                    frameTimer.Start();
                    return;
                }
                if (MasterButtonRadio.Checked)
                {
                    if (!isTransaction)
                    {
                        buffer.Clear();
                        return;
                    }
                    isTransaction = false;
                    timer.Stop();
                    LogMessage("Transakcja zakończona powodzeniem");


                    if (numericUpDown6.Value == 2)
                    {

                        InvokeOrNot(() =>
                        {
                            ReceiveTextPanelASCII.AppendText(StringParser.ByteToDisplay(StringParser.GetModbusMessage(buffer.ToArray())) + "\n");
                        }, ReceiveTextPanelASCII);
                    }
                    else
                    {
                        InvokeOrNot(() =>
                        {
                            ReceiveTextPanelASCII.AppendText("\n");
                        }, ReceiveTextPanelASCII);
                    }
                    InvokeOrNot(() =>
                    {
                        ReceiveTextPanelFrame.AppendText(StringParser.ByteToDisplay(buffer.ToArray()) + "\n");
                    }, ReceiveTextPanelFrame);
                    buffer.Clear();
                    EndTransaction();
                    return;
                }
                if (buffer[4] == 50)
                {
                    string msgString = StringParser
                    .FormatMessageToModbus(textBox1.Text, 2, (byte)numericUpDown7.Value);
                    byte[] msg = StringParser.StrToByteArray(msgString);
                    sendMsg(msg);
                    buffer.Clear();
                    return;
                }
                else
                {
                    InvokeOrNot(() =>
                    {
                        ReceiveTextPanelASCII.AppendText(StringParser.ByteToDisplay(StringParser.GetModbusMessage(buffer.ToArray())) + "\n");
                    }, ReceiveTextPanelASCII);
                    InvokeOrNot(() =>
                    {
                        ReceiveTextPanelFrame.AppendText(StringParser.ByteToDisplay(buffer.ToArray()) + "\n");
                    }, ReceiveTextPanelFrame);
                }
                if ((buffer[1] == 48) && ((buffer[2] == 48)))
                {

                }
                else
                {
                    string msgString = StringParser
                    .FormatMessageToModbus("", 1, (byte)numericUpDown7.Value);
                    byte[] msg = StringParser.StrToByteArray(msgString);
                    sendMsg(msg);
                }
                buffer.Clear();
                //wypisz co dostales
            }

        }

        #region Śmieci





        private void SettingListBitDataPool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SettingListStop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SettingControlFlewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SettingListControlBit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void RSTerminatorLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown4_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown5_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        #endregion
        private void ConnectPing_Click(object sender, EventArgs e)
        {
       

            if (serialPort != null)
                serialPort.Dispose();   // cannot wait for a garbage collector
            if (ConnectButton.Text == "Rozłącz")
            {
                EnableSettingsFunction();
                DisableConnectFunction();
                ConnectButton.Text = "Połącz";
                return;
            }
            SetControlEnum();
            int parityIndex = SettingParityComboBox.SelectedIndex;
            Parity parity = Parity.None;
            switch (parityIndex)
            {
                case 0:
                    parity = Parity.None;
                    break;
                case 1:
                    parity = Parity.Even;
                    break;
                case 2:
                    parity = Parity.Odd;
                    break;
            }
            StopBits stopBits = StopBits.None;
            int stopBitsIndex = SettingStopBitComboBox.SelectedIndex;
            switch (stopBitsIndex)
            {
                case 0:
                    stopBits = StopBits.One;
                    break;
                case 1:
                    stopBits = StopBits.Two;
                    break;
            }
            serialPort = new SerialPort(portComboBox.SelectedItem.ToString(),
                Convert.ToInt32(SettingSpeedComboBox.Text),
                    parity,
                    Convert.ToInt32(SettingDataPoolComboBox.SelectedItem),
                    stopBits);

            serialPort.DataReceived += this.OnDataReceived;


            try
            {
                serialPort.Open();

                if (!serialPort.IsOpen)
                {
                    LogMessage("Nie można połączyć z portem.");
                    return;
                }
                EnableConnectingFunction();
                DisableSettingsFunction();
                ConnectButton.Text = "Rozłącz";


            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ReloadPorts();

            SettingDataPoolComboBox.SelectedIndex = 1;
            SettingStopBitComboBox.SelectedIndex = 0;
            SettingParityComboBox.SelectedIndex = 0;
            SettingControlFlewComboBox.SelectedIndex = 0;
            SettingSpeedComboBox.SelectedIndex = 4;
        }

        private void sendMsg(byte[] msg)
        {
            try
            {
                serialPort.Write(msg, 0, msg.Length);
                InvokeOrNot(() =>
                {
                    LogOutput.AppendText("Wysłano:\n" + StringParser.ByteToDisplay(msg, DataFormat.HEX) + " => " + StringParser.ByteToDisplay(msg) + "\n");
                }, LogOutput);
                lastSentMsg = msg;
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
                return;
            }
        }
        private void StartTransaction(byte[] msg)
        {
            if (pingWait)
            {
                timer.Interval = Convert.ToInt32(TimePing.Text) == 0 ? 1 : Convert.ToInt32(TimePing.Text);
            } else
            {
                timer.Interval = numericUpDown1.Value == 0 ? 1 : (int)numericUpDown1.Value;
                retransmisions = (int)numericUpDown2.Value;
            }
            timer.Start();
            isTransaction = true;
            sendMsg(msg);
            return;
        }

        private void EndTransaction()
        {
            pingWait = false;
            isTransaction = false;
            retransmisions = 0;
            buffer.Clear();
        }

        private bool IsPing(byte[] msg)
        {
            if (msg == null)
            {
                return false;
            }
            if (msg.Length != 4)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (pingArr[i] != msg[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsPong(byte[] msg)
        {
            if (msg == null)
            {
                return false;
            }
            if (msg.Length != 4)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (pongArr[i] != msg[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ping
            pingWait = true;
            StartTransaction(pingArr);
        }
        

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(!mode)
            {
                List<byte> msgToSend = new List<byte>();
                msgToSend.AddRange(StringParser.StrToByteArray(textBox1.Text));
                if(terminator != null)
                {
                    msgToSend.AddRange(terminator);
                }
                sendMsg(msgToSend.ToArray());
                InvokeOrNot(() =>
                {
                    LogOutput.AppendText("Wysłano:\n" + textBox1.Text + "\n");
                }, LogOutput);
                
                return;
            }
            if((numericUpDown7.Value == 0) && (numericUpDown6.Value == 2))
            {
                LogMessage("Rozkaz 2 nie może działać w trybie rozgłoszeniowym");
                return;
            }
            string msgString = StringParser
                .FormatMessageToModbus(textBox1.Text, (byte)numericUpDown6.Value, (byte)numericUpDown7.Value);
            byte[] msg = StringParser.StrToByteArray(msgString);
            if (MasterButtonRadio.Checked)
            {
                if(numericUpDown7.Value > 0)
                {
                    StartTransaction(msg);
                    return;
                }
                sendMsg(msg);
            }
        }

        private void InvokeOrNot(Action f, Control ctrl)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke(f);
            else
                f.Invoke();
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            InvokeOrNot(() =>
            {
                if (TabControl.SelectedTab.Text == "RS232")
                {
                    mode = false;
                } else
                {
                    mode = true;
                }
            }, LogOutput);
        }

        private void RSTerminatorButtonCustomAccept_Click(object sender, EventArgs e)
        {
            if (RSTerminatorButtonNone.Checked)
            {
                terminator = null;
                return;
            }
            if (RSTerminatorButtonCR.Checked)
            {
                terminator = new byte[] { 13 };
            }
            if (RSTerminatorButtonLF.Checked)
            {
                terminator = new byte[] { 10 };
            }
            if (RSTerminatorButtonCRLF.Checked)
            {
                terminator = new byte[] { 13, 10 };
            }
            if (RSTerminatorButtonCustom.Checked)
            {
                terminator = StringParser.StrToByteArray(RSTerminatorTextCustom.Text);
            }
            RSTerminatorTextCurrent.Text = terminator == null ? "" : StringParser.ByteToDisplay(terminator);
            buffer.Clear();
            terminatorReceived = true
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buffer.Clear();
            terminatorReceived = true
        }
    }
}
