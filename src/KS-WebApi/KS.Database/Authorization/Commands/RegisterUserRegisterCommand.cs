using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Command
{
    public class RegisterUserRegisterCommand : IAuthorizationCommand
    {
        public Task<bool> Execute(NewUserCreateDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
