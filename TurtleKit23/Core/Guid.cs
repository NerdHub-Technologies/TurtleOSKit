/* Guid.cs
 * ---------------
 * Project: TurtleKit-Beta
 * Organization: 32bit Restoration Project
 * Developers:
 *      WinMister332 <cemberley@nerdhub.net>
 * License: MIT <license.txt>
 * ---------------
 * Copyright (c) 32bit Restoration Project 2022, All Rights Reserved.
 */
using IL2CPU.API.Attribs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurtleOSKit.Utilities;

using DGuid = System.Guid;

namespace TurtleOSKit.Core
{
    public sealed class Guid
    {
        private DGuid guid;

        Guid(DGuid guid)
        {
            this.guid = guid;
        }

        public byte[] ToByteArray()
            => guid.ToByteArray();

        public bool TryWriteBytes(Span<byte> destination)
            => guid.TryWriteBytes(destination);

        public bool Equals(DGuid dguid)
            => guid == dguid;

        public bool Equals(Guid guid)
            => Equals(guid.guid);

        public bool Equals(string s)
            => ToString().ToUpper().Equals(s.ToUpper());

        public override bool Equals(object o)
        {
            if (o is string)
                return Equals((string)o);
            else if (o is Guid)
                return Equals((Guid)o);
            else if (o is DGuid)
                return Equals((DGuid)o);
            else
                return false;
        }

        public override string ToString()
            => ToString("D");

        public string ToString(string format)
            => guid.ToString(format);

        public static bool operator ==(Guid left, Guid right)
            => left.Equals(right);
        public static bool operator ==(Guid left, DGuid right)
            => left.Equals(right);
        public static bool operator !=(Guid left, Guid right)
            => !left.Equals(right);
        public static bool operator !=(Guid left, DGuid right)
            => !left.Equals(right);


        public static Guid Parse(string s)
        {
            var x = DGuid.TryParse(s, out DGuid result);
            if (x)
                return new Guid(result);
            else
                return new Guid(DGuid.Empty);
        }

        public static Guid NewGuid()
        {
            var rng = RNG.INSTANCE;
            string s = "YXXXXXXY-XXYX-XYXX-XXXY-ZXXXYXXXXXYX";
            char[] sn = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                var x = s[i];
                if (x == 'Y')
                {
                    //The 'Y' byte table.
                    var yBytes = new byte[]
                    {
                        0x30, //1
                        0x34, //4
                        0x36, //6
                        0x41, //A
                        0x42, //B
                        0x43 //C
                    };
                    sn[i] = (char)rng.NextByte(yBytes);
                }
                else if (x == 'X')
                    sn[i] = (char)rng.NextByte(rng.GenerateHexBytes());
                else if (x == 'Z')
                {
                    var n = rng.NextInt(1, 10);
                    if (n.IsEven())
                        sn[i] = (char)0x42;
                    else
                        sn[i] = (char)0x32;
                }
                else
                    sn[i] = '-';
            }
            return Parse(new string(sn));
        }
    }
}
