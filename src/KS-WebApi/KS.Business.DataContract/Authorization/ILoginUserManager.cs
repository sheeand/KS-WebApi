using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface ILoginUserManager
    {
        //TODO: 1 - Generate token for user method (received DTO) - return string
        //TODO: 0.5 Fix this
        Task<ReceivedUserLoginDTO> LoginUser(GetUserDTO userLogin);
    }
}
