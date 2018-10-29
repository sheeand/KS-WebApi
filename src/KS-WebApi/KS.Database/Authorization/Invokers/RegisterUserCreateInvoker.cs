using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Invoker
{
    public class RegisterUserCreateInvoker : IUserRegistrationInvoker
    {
        public Task<bool> InvkokeRegisterUserCommand(NewUserCreateDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
