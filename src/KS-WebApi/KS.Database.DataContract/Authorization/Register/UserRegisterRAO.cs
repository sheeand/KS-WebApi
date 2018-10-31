using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.DataContract.Authorization.Register
{
    public class UserRegisterRAO
    {
        public string Username { get; set; }
        //public Guid OwnerId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }

}
