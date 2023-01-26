using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TurtleOSKit.Core
{
    public static class Converter
    {
        public static byte ToByte(char c)
            => (byte)c;
        public static char ToChar(byte c)
            => (char)c;
        public static char[] ToCharArray(string s)
        {
            char[] x = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
                x[i] = s[i];
            return x;
        }

        public static char[] ToCharArray(byte[] b)
        {
            char[] x = new char[b.Length];
            for (int i = 0; i < b.Length; i++)
                x[i] = (char)b[i];
            return x;
        }

        public static char[] ToCharArray(int[] i)
        {
            char[] x = new char[i.Length];
            for (int ix = 0; ix < i.Length; ix++)
                x[ix] = (char)i[ix];
            return x;
        }

        public static byte[] ToBytes(int[] i)
            => ToBytes(ToCharArray(i));
        public static byte[] ToBytes(char[] c)
        {
            byte[] x = new byte[c.Length];
            for (int i = 0; i < c.Length; i++)
                x[i] = (byte)c[i];
            return x;
        }

        public static byte[] ToBytes(string s)
            => ToBytes(ToCharArray(s));

        public static string ToString(byte[] b)
            => ToString(ToCharArray(b));

        public static string ToString(char[] c)
            => new string(c);

        public static string ToHex(uint dec)
        {
            var x = dec.ToString("X");
            if (!x.StartsWith("0x"))
                x = $"Ox{x}";
            return x;
        }

        public static string ToHex(int dec)
            => ToHex((uint)dec);
    }
}
