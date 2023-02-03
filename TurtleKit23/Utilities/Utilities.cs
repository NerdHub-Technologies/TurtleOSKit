/* Utilities.cs
 * ---------------
 * Project: TurtleKit-Beta
 * Organization: 32bit Restoration Project
 * Developers:
 *      WinMister332 <cemberley@nerdhub.net>
 * License: MIT <license.txt>
 * ---------------
 * Copyright (c) 32bit Restoration Project 2022, All Rights Reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using TurtleOSKit.Core;

namespace TurtleOSKit.Utilities
{
    public static class Utilities
    {
        public static bool IsNull(this string s)
            => s == null;
        public static bool IsEmpty(this string s)
            => s == "";
        public static bool IsWhiteSpace(this string s)
            => s == " ";

        public static bool IsNullOrEmpty(this string s)
            => IsNull(s) || IsEmpty(s);
        public static bool IsNullOrWhiteSpace(this string s)
            => IsNull(s) || IsWhiteSpace(s);
        public static bool IsNullWhiteSpaceOrEmpty(this string s)
            => IsNullOrEmpty(s) || IsNullOrWhiteSpace(s);

        public static bool EqualsIgnoreCase(this string s, in string value)
            => s.ToLower() == value.ToLower();

        public static T[] Skip<T>(this T[] tArr, int cnt)
        {
            List<T> sL = new List<T>();
            for (int i = 0; i < tArr.Length; i++)
            {
                if (i <= (cnt - 1))
                    continue;
                sL.Add(tArr[i]);
            }
            return sL.ToArray();
        }

        public static int ToInt(this sbyte b)
            => b;
        public static uint ToUInt(this byte b)
            => b;

        public static string ToHex(this byte b)
            => Converter.ToHex(b.ToUInt());
        public static string ToHex(this sbyte b)
            => Converter.ToHex(b.ToInt());

        public static byte[] GetBytes(this char[] c)
        {
            byte[] b = new byte[c.Length];
            for (int i = 0; i < b.Length; i++)
                b[i] = (byte)c[i];
            return b;
        }

        public static byte[] GetBytes(this string s)
            => s.ToCharArray().GetBytes();

        public static string GetHexString(this byte b)
            => b.ToString("X2");

        public static string GetString(this byte[] b)
        {
            var x = Convert.ToHexString(b);
            if (!x.StartsWith("0x"))
                x = $"0x{x}";
            return x;
        }

        public static string ToSafe(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c) && !(c.IsSanitySpecial() || char.IsSymbol(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c)))
                    sb.Append(c);
                else continue;
            }
            return sb.ToString();
        }

        public static bool IsSanitySpecial(this char c)
            => c == 0xE2808B;

        public static bool IsEven(this int i)
            => i % 2 == 0;
        public static bool IsEven(this short s)
            => s % 2 == 0;
        public static bool IsEven(this long l)
            => l % 2 == 0;
    }
}
