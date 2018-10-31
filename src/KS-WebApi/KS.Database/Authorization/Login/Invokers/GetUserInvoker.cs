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
        private readonly IAuthorizationGetUserCommand _command;

        public GetUserInvoker(IAuthorizationGetUserCommand command)
        {
            _command = command;
        }

        // no mapping ncessary
        public async Task<bool> InvokeGetUserCommandAsync(GetUserDTO userDTO)
        {
            return await _command.Execute(userDTO);
        }
    }
}
