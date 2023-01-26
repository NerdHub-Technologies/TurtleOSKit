/* AccountType.cs
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

namespace TurtleOSKit.Users
{
    public enum AccountType
    {
        GUEST = -2,
        CHILD = -1,
        USER = 0,
        ADMIN = 1,
        SYSTEM = 2,
        RECOVERY = 3
    }
}
