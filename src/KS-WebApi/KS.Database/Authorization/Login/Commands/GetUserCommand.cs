using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Commands
{
    public class GetUserCommand
    {
        private readonly IAuthorizationGetUserReceiver _receiver;

        public GetUserCommand(IAuthorizationGetUserReceiver receiver)
        {
            _receiver = receiver;
        }

        public async Task<bool> GetUserByUsername(GetUserRAO userRAO)
        {
            return await _receiver.GetUserByUsername(userRAO);
        }
    }
}
