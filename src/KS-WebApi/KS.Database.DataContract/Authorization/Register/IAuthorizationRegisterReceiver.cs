using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization.Register
{
    public interface IAuthorizationRegisterReceiver
    {
        Task<bool> RegisterUser(UserRegisterRAO userDTO);
        //-- Login
        //-- User authentication check

    }
}
