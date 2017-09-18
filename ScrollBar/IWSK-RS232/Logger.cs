using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IWSK_RS232
{
    class Logger
    {
        public void LogMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
}
