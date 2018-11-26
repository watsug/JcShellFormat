using System;
using System.Text;

namespace Watsug.JcShellFormat.Util
{
    public static class HexEncoding
    {
        public static readonly char[] LowerCaseHex = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
        public static readonly char[] UpperCaseHex = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static string BinToHex(byte[] buff, bool upperCase = true)
        {
            if (buff == null) throw new NullReferenceException(nameof(buff));

            char[] tmpCase = upperCase ? UpperCaseHex : LowerCaseHex;
            char[] tmp = new char[buff.Length * 2];
            for (int i=0; i < buff.Length; i++)
            {
                int j = i << 1;
                byte b = buff[i];
                tmp[j] = tmpCase[b >> 4];
                tmp[j+1] = tmpCase[b & 0x0f];
            }

            return new string(tmp);
        }
    }
}