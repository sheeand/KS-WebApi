using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receiver
{
    public class RegisterUserCreateReceiver : IAuthorizationReceiver
    {
        public Task<bool> RegisterUser(NewUserCreateDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
