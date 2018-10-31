using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Register;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Register.Commands
{
    public class RegisterUserCreateCommand : IAuthorizationRegisterCommand
    {
        private readonly IAuthorizationRegisterReceiver _receiver;

        public RegisterUserCreateCommand(IAuthorizationRegisterReceiver receiver)
        {
            _receiver = receiver;
        }
        public async Task<bool> Execute(UserRegisterRAO userRAO)
        {
            return await _receiver.RegisterUser(userRAO);
        }
    }
}
