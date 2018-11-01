using KS.Business.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.DataContract.Authorization.Login
{
    public interface IGetUserInvoker
    {
        Task<bool> InvokeGetUserCommandAsync(GetUserRAO userDTO);
    }
}
