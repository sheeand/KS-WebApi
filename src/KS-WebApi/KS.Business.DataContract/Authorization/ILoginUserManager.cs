using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface ILoginUserManager
    {
        //TODO: 0.5 Fix this
        Task<ReceivedUserLoginDTO> LoginUser(GetUserDTO userLogin);

        //TODO: 1 - Generate token for user method (received DTO) - return string
        string GenerateTokenForUser(ReceivedUserLoginDTO receivedUserLoginDTO);

    }
}
