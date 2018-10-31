using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization.Login
{
    public interface IAuthorizationLoginReceiver
    {
        Task<bool> LoginUser(UserLoginRAO userDTO);
        //-- Login
        //-- User authentication check

    }
}
