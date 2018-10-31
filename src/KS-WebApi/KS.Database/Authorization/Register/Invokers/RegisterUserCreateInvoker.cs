using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Register;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Register.Invokers
{
    public class RegisterUserCreateInvoker : IUserRegisterInvoker
    {
        private readonly IAuthorizationRegisterCommand _command;

        public RegisterUserCreateInvoker(IAuthorizationRegisterCommand command)
        {
            _command = command;
        }

        // no mapping ncessary
        public async Task<bool> InvokeRegisterUserCommand(UserRegisterRAO userRAO)
        {
            return await _command.Execute(userRAO);
        }
    }
}
