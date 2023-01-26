using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurtleOSKit.Core;
using TurtleOSKit.Utilities;

using Guid = TurtleOSKit.Core.Guid;

namespace TurtleOSKit.Users
{
    public sealed class UserHashData
    {
        //TODO: For hashing passwords!

        private Guid userID;
        private DateTime timeCreated;

        private readonly string passHash;

        UserHashData(in Guid guid, in DateTime time, in string password, in string padding)
        {

        }

        private static string Format(in Guid guid, in DateTime time, in string password)
        {
            var timeFormat = "yyyy/MM/dd @ HH:mm:ss K";
            var timeStr = time.ToString(timeFormat);
            var guidStr = guid.ToString();
            return $"__#({guidStr})__!<{password}>__@[{timeStr}]__";
        }
    }
}
