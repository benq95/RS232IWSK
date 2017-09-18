using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;

namespace IWSK_RS232
{
    class SentEventArgs : EventArgs
    {
        private byte[] buffer;

        public byte[] Buff
        {
            get { return buffer; }
        }

        public SentEventArgs(byte[] buff)
            : base()
        {
            if (buff == null)
                buffer = null;
            else
            {
                buffer = new byte[buff.Length];
                Buffer.BlockCopy(buff, 0, buffer, 0, buffer.Length);
            }
        }
    }

    class TransactionEventArgs : EventArgs
    {
        public bool TransactionResult { private set; get; }

        public TransactionEventArgs(bool result)
            : base()
        {
            TransactionResult = result;
        }
    }

    delegate void DataSentEventHandler(object sender, SentEventArgs e);
    delegate void TransactionEventHandler(object sender, TransactionEventArgs e);

    class RS232Port 
    {
        private SerialPort serialPort;
        private string portName;
        private int baudRate;
        private Parity parity;
        private StopBits stopBits;
        private int dataBits;
        private static Parity[] parityArray = { Parity.None, Parity.Even, Parity.Odd/*, Parity.Mark, Parity.Space*/ };
        private static StopBits[] stopBitsArray = { StopBits.One, /*StopBits.OnePointFive,*/ StopBits.Two };
        private List<byte> readBytes = new List<byte>();
        private System.Windows.Forms.Timer transactionTimer = new System.Windows.Forms.Timer();
        private bool isTransaction = false;
        private bool transactionSuccess = true;
        private bool dtrEnable = false;
        private bool rtsEnable = false;

        public RS232Port()
        {
            transactionTimer.Tick += (sender, e) => { 
                transactionTimer.Stop(); 
                OnTransactionFinished(new TransactionEventArgs(false));
                transactionSuccess = false;
                isTransaction = false; 
            };
        }

        public void SetConnectionParameters(string portName, int baudRate, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.None)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.parity = parity;
            this.dataBits = dataBits;
            this.stopBits = stopBits;
        }

        public bool Connect()
        {
            if(serialPort != null)
                serialPort.Dispose();   // cannot wait for a garbage collector

            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DataReceived += port_DataReceived;
            serialPort.PinChanged += port_PinChanged;

            if (serialPort.IsOpen)
                return true;

            try
            {
                serialPort.Open();

                if (!serialPort.IsOpen)
                    return false;

                serialPort.DtrEnable = DTREnable;
                serialPort.RtsEnable = RTSEnable;
                OnConnected(EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool Disconnect()
        {
            if (!serialPort.IsOpen)
                return true;

            try
            {
                serialPort.Close();
                serialPort.DataReceived -= port_DataReceived;   // because of memory leaks
                serialPort.PinChanged -= port_PinChanged;
            }
            catch (IOException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }

            OnDisconnected(EventArgs.Empty);

            return true;
        }

        public bool Send(byte[] buf, bool unsafeMode = false)
        {
            if (buf == null)
                return true;
            transactionSuccess = true;
            try
            {
                serialPort.Write(buf, 0, buf.Length);

                if (!unsafeMode)
                {
                    OnDataSent(new SentEventArgs(buf));
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false; 
            }
        }

        public void port_DataReceived(object sender, EventArgs e)
        {
            transactionTimer.Stop();
            
            if (isTransaction)
            {
                isTransaction = false;
                OnTransactionFinished(new TransactionEventArgs(true));
            }
            int toRead = serialPort.BytesToRead;
            byte[] buffer = new byte[toRead];

            serialPort.Read(buffer, 0, toRead);
            if(transactionSuccess)
            {
                readBytes.AddRange(buffer);
                OnDataReceived(EventArgs.Empty);
            }
            transactionSuccess = true;

            
        }

        public void port_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            OnPinChanged(e);
        }

        public List<byte> GetReadBytes()
        {
            List<byte> newList = new List<byte>(readBytes);

            readBytes.Clear();

            return newList;
        }

        public bool IsOpen
        {
            get { return serialPort != null && serialPort.IsOpen; }
        }

        public bool IsTransaction
        {
            get { return isTransaction; }
        }

        public string ErrorMessage
        {
            get;
            private set;
        }

        public bool RTSEnable
        {
            set
            {
                rtsEnable = value;
                serialPort.RtsEnable = rtsEnable;
            }
            get { return rtsEnable; }
        }

        public bool DTREnable
        {
            set
            {
                dtrEnable = value;
                serialPort.DtrEnable = dtrEnable;
            }
            get { return dtrEnable; }
        }

        public bool DSR
        {
            get {  return IsOpen && serialPort.DsrHolding; }
        }

        public bool CTS
        {
            get { return IsOpen && serialPort.CtsHolding; }
        }

        public static Parity ParityArray(int index)
        {
            return parityArray[index];
        }

        public static StopBits StopBitsArray(int index)
        {
            return stopBitsArray[index];
        }


#region events
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler DataReceived;
        public event TransactionEventHandler TransactionFinished;
        public event DataSentEventHandler DataSent;
        public event SerialPinChangedEventHandler PinChanged;

        private void OnConnected(EventArgs e)
        {
            if (Connected != null)
                Connected(this, e);
        }

        private void OnDisconnected(EventArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }

        private void OnDataReceived(EventArgs e)
        {
            if (DataReceived != null)
                DataReceived(this, e);
        }

        private void OnDataSent(SentEventArgs e)
        {
            if (DataSent != null)
                DataSent(this, e);
        }

        private void OnTransactionFinished(TransactionEventArgs e)
        {
            if (TransactionFinished != null)
                TransactionFinished(this, e);
        }

        private void OnPinChanged(SerialPinChangedEventArgs e)
        {
            if (PinChanged != null)
                PinChanged(this, e);
        }
#endregion

        public void SetTransaction(int interval)
        {
            transactionTimer.Interval = interval;
            transactionTimer.Start();
            isTransaction = true;
        }
    }
}
