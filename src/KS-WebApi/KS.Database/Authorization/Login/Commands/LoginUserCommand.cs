using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Commands
{
    public class LoginUserCommand : IAuthorizationLoginCommand
    {
        private readonly IAuthorizationLoginReceiver _receiver;

        public LoginUserCommand(IAuthorizationLoginReceiver receiver)
        {
            _receiver = receiver;
        }

        public async Task<bool> Execute(UserLoginRAO userDTO)
        {
            return await _receiver.LoginUser(userDTO);
        }
    }
}
