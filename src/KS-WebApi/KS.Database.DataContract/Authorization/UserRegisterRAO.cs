using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.DataContract.Authorization
{
    public class UserRegisterRAO
    {
        public string Username { get; set; }
        public Guid Password { get; set; }
        public byte[] PassHash { get; set; }
        public byte[] PassSalt { get; set; }

    }

}
