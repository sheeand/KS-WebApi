using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Invokers
{
    class GetUserInvoker
    {
        private readonly IAuthorizationLoginCommand _command;

        public GetUserInvoker(IAuthorizationLoginCommand command)
        {
            _command = command;
        }

        // no mapping ncessary
        public async Task<ReceivedUserLoginRAO> InvokeGetUserCommandAsync(GetUserRAO userRAO)
        {
            return await _command.Execute(userRAO);
        }
    }
}
