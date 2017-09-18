using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IWSK_RS232
{
    enum DataFormat { ASCII, HEX, DEC }

    class StringParser
    {
        static Dictionary<char, byte> spCHArray = new Dictionary<char, byte>();

        static StringParser()
        {
            spCHArray.Add('n', 10);
            spCHArray.Add('r', 13);
            spCHArray.Add('0', 9);
            spCHArray.Add('\\', 92);
        }

        public static byte? SpecialCharacter(char sign)
        {
            if (spCHArray.ContainsKey(sign))
                return spCHArray[sign];
            else
                return null;
        }

        public static string ByteToDisplay(byte[] byteArray, DataFormat p = DataFormat.ASCII)
        {
            StringBuilder text = new StringBuilder(byteArray.Length);

            for (int i = 0; i < byteArray.Length; i++)
            {
                switch (p)
                {
                    case DataFormat.HEX:
                        text.Append("{x" + byteArray[i].ToString("X2") + "}");
                        break;

                    case DataFormat.DEC:
                        text.Append("{d" + byteArray[i].ToString("D3") + "}");
                        break;

                    case DataFormat.ASCII:
                        text.Append(Convert.ToChar(byteArray[i]));
                        break;
                }
            }

            return text.ToString();
        }

        public static byte[] StrToByteArray(string str)
        {
            List<byte> conBytes = new List<byte>();
            int i;

            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == '\\')
                {
                    if (i + 1 == str.Length)
                        break;

                    switch (str[i + 1])
                    {
                        case 'x':
                            if (i + 3 == str.Length)
                                break;

                            conBytes.Add(Convert.ToByte(str.Substring(i + 2, 2), 16));
                            i += 3;
                            break;
                        case 'd':
                            if (i + 4 == str.Length)
                                break;

                            conBytes.Add(Convert.ToByte(str.Substring(i + 2, 3), 10));
                            i += 4;
                            break;

                        default:
                            byte? spec = SpecialCharacter(str[++i]);

                            if ( spec != null)
                                conBytes.Add(spec.Value);

                            break;
                    }
                }
                else
                    conBytes.Add(Convert.ToByte(str[i]));
            }

            if (i != str.Length)
                throw new Exception("Nie można sparsować stringa.");

            return conBytes.ToArray();
        }

        public static string FormatMessageToModbus(string str, byte instrNumber, byte address)
        {
            byte begin = (byte)58;
            
            byte[] myByte = System.Text.ASCIIEncoding.Default.GetBytes(str);
            byte lrc = myByte.Aggregate<byte, byte>(0, (x, y) => (byte)(x ^ y));
            List < byte > bytes = new List<byte>();
            bytes.Add(address);
            bytes.Add(instrNumber);
            foreach(byte b in myByte)
            {
                bytes.Add(b);
            }
            bytes.Add(lrc);
            StringBuilder hex = new StringBuilder(bytes.Count * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            string hexMessage = hex.ToString();
            hexMessage = Convert.ToChar(begin) + hexMessage + Convert.ToChar((byte)13) + Convert.ToChar((byte)10);
            return hexMessage;
        }

        public static bool CheckModbusMessage(byte [] frame, byte address)
        {
            try
            {
                if (frame.Length < 9)
                {
                    return false;
                }
                if(frame.Length % 2 == 0)
                {
                    return false;
                }
                if (frame[0] != 58)
                {
                    return false;
                }
                if ((ByteHexToInt(frame[1])*16 + ByteHexToInt(frame[2]) != address) && (ByteHexToInt(frame[1])*16 + ByteHexToInt(frame[2]) != 0))
                {
                    return false;
                }
                int instr = ByteHexToInt(frame[3])*16 + ByteHexToInt(frame[4]);
                if ((instr == 2) && (ByteHexToInt(frame[1])*16 + ByteHexToInt(frame[2]) > 1))
                {
                    return false;
                }
                if ((instr < 1) || (instr > 2))
                {
                    return false;
                }
                if((frame[frame.Length - 2] != 13)||(frame[frame.Length - 1] != 10))
                {
                    return false;
                }
                List <byte>message = new List<byte>();
                for (int i = 5; i < frame.Length - 4; i+=2)
                {
                    message.Add((byte)(ByteHexToInt(frame[i])*16 + ByteHexToInt(frame[i+1])));
                }
                byte lrc = (byte)(ByteHexToInt(frame[frame.Length-4])*16 + ByteHexToInt(frame[frame.Length-3]));
                if ((message.Count == 0)&&(lrc == 0))
                {
                    return true;
                }
                byte trueLrc = message.Aggregate<byte, byte>(0, (x, y) => (byte)(x ^ y));
                if(lrc != trueLrc)
                {
                    return false;
                }
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }
        private static byte ByteHexToInt(byte hex)
        {
            char c = Convert.ToChar(hex);
            string hexStr = c.ToString();
            return (byte)Convert.ToInt32(hexStr, 16);
        }

        public static byte [] GetModbusMessage(byte [] msg)
        {
            if(msg.Length == 9)
            {
                return new byte [0];
            }
            List<byte> message = new List<byte>();
            for (int i = 5; i < msg.Length - 4; i += 2)
            {
                message.Add((byte)(ByteHexToInt(msg[i])*16 + ByteHexToInt(msg[i + 1])));
            }
            return message.ToArray();
        }
    }
    
}
