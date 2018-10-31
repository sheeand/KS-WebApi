using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface ILoginUserManager
    {
        Task<bool> LoginUser(UserLoginDTO userLogin);
    }
}
