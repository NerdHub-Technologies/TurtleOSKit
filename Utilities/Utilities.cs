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
using System.Text;
using System.Threading.Tasks;

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
    }
}
