/* AccountStatus.cs
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
    public enum AccountStatus
    {
        DISABLED = 0,
        NO_USERNAME_PROVIDED = -6,
        PARENTALCONTROLS_BEDTIME_REACHED = -5,
        PARENTALCONTROLS_TIMELIMIT_EXPIRED = -4,
        PARENTALCONTROLS_CURFEW_REACHED = -3,
        NO_PASSWORD_PROVIDED = -2,
        ACCESS_DENIED = -1,
        NO_PASSWORD_REQUIRED = 1,
        ACCESS_GRANTED = 2
    }
}
