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

        public Form1()
        {
            InitializeComponent();
            DisableConnectFunction();


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

        private void ReloadPorts()
        {
            PortList.DataSource = SerialPort.GetPortNames();

            if (PortList.Items.Count > 0)
            {
                PortList.SelectedIndex = 0;
                ConnectButton.Enabled = true;
            }
            else
            {
                LogMessage("Nie odnaleziono portów COM w komputerze.");
                ConnectButton.Enabled = false;
            }
        }

        private void sendMsg(byte[] msg)
        {
            try
            {
                serialPort.Write(msg, 0, msg.Length);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
                return;
            }
        }

        public void LogMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }

    

        private void OnDataReceived(object sender, EventArgs e)
        {

        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadPorts();

            SettingListBitDataPool.SelectedIndex = 1;
            SettingListStop.SelectedIndex = 0;
            SettingListParity.SelectedIndex = 0;
            SettingListControlFlew.SelectedIndex = 0;

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RSTerminatorLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
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

        private void ConnectPing_Click(object sender, EventArgs e)
        {
            DisableSettingsFunction();
            EnableConnectingFunction();

            if (serialPort != null)
                serialPort.Dispose();   // cannot wait for a garbage collector
            if (ConnectButton.Text == "Rozłącz")
            {
                DisableSettingsFunction();
                EnableConnectingFunction();
                ConnectButton.Text = "Połącz";
                return;
            }
            int parityIndex = SettingListParity.SelectedIndex;
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
            int stopBitsIndex = SettingListStop.SelectedIndex;
            switch (stopBitsIndex)
            {
                case 0:
                    stopBits = StopBits.One;
                    break;
                case 1:
                    stopBits = StopBits.Two;
                    break;
            }
            serialPort = new SerialPort(PortList.SelectedItem.ToString(),
                Convert.ToInt32(SettingListSpeed.Text),
                    parity,
                    Convert.ToInt32(SettingListBitDataPool.SelectedItem),
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
                DisableConnectFunction();
                EnableSettingsFunction();             
                ConnectButton.Text = "Rozłącz";
               

            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }
    }
}
