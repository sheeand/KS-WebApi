using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.DataContract.Authorization.Login
{
    public class ReceivedUserLoginRAO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
