using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IWSK_RS232
{
    class Parser
    {
        private List<byte> bytes = new List<byte>();
        private byte[] terminator;
        private int terminatorIt = 0;
        private List<byte> frame = null;

        public event EventHandler FrameParsed;

        private void OnFrameParsed(EventArgs e)
        {
            if (FrameParsed != null)
                FrameParsed(this, e);
        }

        public Parser(byte[] terminator = null)
        {
            this.terminator = terminator;
        }

        public void AppendToParser(IEnumerable<byte> newBytes)
        {
            bool empty = TerminatorEmpty(Terminator);
            
            if (empty)
                return;

            foreach (var b in newBytes)
            {
                bytes.Add(b);

                if (!empty && b == terminator[terminatorIt])
                {
                    terminatorIt++;

                    if (terminatorIt == terminator.Length)
                    {
                        frame = new List<byte>(bytes.Take(bytes.Count - terminator.Length));
                        OnFrameParsed(null);
                        bytes.Clear();
                        terminatorIt = 0;
                    }
                }
                else
                {
                    terminatorIt = 0;                    
                }                
            }
        }

        public byte[] Frame
        {
            get { return frame.ToArray(); }
        }

        public byte[] Terminator
        {
            set
            {
                if (TerminatorEmpty(value))
                {
                    bytes.Clear();
                }
                else terminator = value;
            }
            get { return terminator; }
        }

        private bool TerminatorEmpty(byte[] terminator)
        {
            return terminator == null || terminator.Length == 0;
        }
    }
}
