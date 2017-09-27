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
using System.Threading.Tasks;


namespace TestAplication
{
    public partial class Form1 : Form
    {
        SerialPort port1;
        SerialPort port2;

        public void SendToPort(SerialPort port, Byte [] bytes)
        {
            port.Write(bytes, 0, bytes.Length);
        }

        public Byte[] GetFromPort(SerialPort port)
        {
            int toRead = port.BytesToRead;
            byte[] buffer = new byte[toRead];

            port.Read(buffer, 0, toRead);
            return buffer;
        }

        public void   port_DataReceived1(object sender, EventArgs e)
        {
            SendOneBytes(port1, port2);
        }
        public void port_DataReceived2(object sender, EventArgs e)
        {
            SendOneBytes(port2, port1);
        }

        public Form1()
        {
            Byte[] bytes = { 23, 23, 23 };
          //  SerialPort seriaport = new SerialPort("COM4");
          //  SerialPort seriaport2 = new SerialPort("COM7");
            port1= new SerialPort("COM5");
            port2 = new SerialPort("COM6");
            port1.DataReceived += port_DataReceived1;
            port2.DataReceived += port_DataReceived2;
           
            //seriaport.DataReceived+= port_DataReceived1;
            port1.Open();
            port2.Open();
           // seriaport.Open();
            //seriaport2.Open();

          
         //   SendToPort(seriaport, bytes);
           // Byte[] bytes2 = GetFromPort(port2);
            InitializeComponent();
        }

        private void Port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SendOneBytes(SerialPort source, SerialPort target)
        {
            Byte[] bytes = GetFromPort(source);
            for (int i = 0; i < bytes.Length;)
            {
                Byte[] smallBytes = new byte[1];
                smallBytes[0] = bytes[0];
                SendToPort(target, smallBytes);
                bytes = bytes.Where((val, idx) => idx != 0).ToArray();
                Task.Delay(100);
            }
        }


    }
}
