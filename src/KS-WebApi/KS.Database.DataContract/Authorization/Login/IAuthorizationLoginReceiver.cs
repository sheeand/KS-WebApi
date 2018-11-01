using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization.Login
{
    public interface IAuthorizationLoginReceiver
    {

        // TODO: 0.2 Fix this
        Task<ReceivedUserLoginRAO> LoginByUsername(GetUserRAO userRAO);
    }
}
