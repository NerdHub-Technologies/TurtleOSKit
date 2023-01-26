/* User.cs
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

using TurtleOSKit.Utilities;

namespace TurtleOSKit.Users
{
    public class User
    {
        private string username, passwordHash, email, firstName, lastName;
        private DateTime timeCreated;
        private DateTime? lastLogin;
        private bool isLoggedIn = false, enabled = true;
        private Guid guid;
        private AccountType accountType = AccountType.USER;

        User(string username, string password, string email, AccountType accountType = AccountType.USER)
        {
            this.username = username.ToSafe();

        }


    }
}
