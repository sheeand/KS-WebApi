using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Invokers
{
    public class LoginUserInvoker : IUserLoginInvoker
    {
        private readonly IAuthorizationLoginCommand _command;

        public LoginUserInvoker(IAuthorizationLoginCommand command)
        {
            _command = command;
        }

        // no mapping ncessary
        public async Task<ReceivedUserLoginRAO> InvokeLoginUserCommand(GetUserRAO userRAO)
        {
            return await _command.Execute(userRAO);
        }
    }
}
