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
        private readonly IAuthorizationLoginReceiver _receiver;

        public GetUserCommand(IAuthorizationLoginReceiver receiver)
        {
            _receiver = receiver;
        }

        public async Task<ReceivedUserLoginRAO> GetUserByUsername(GetUserRAO userRAO)
        {
            return await _receiver.LoginByUsername(userRAO);
        }
    }
}
