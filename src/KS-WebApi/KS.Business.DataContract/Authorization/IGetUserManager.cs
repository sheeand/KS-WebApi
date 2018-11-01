using KS.Business.DataContract.Authorization;
using System.Threading.Tasks;

namespace KS.API.Controllers.Authorization
{
    public interface IGetUserManager
    {
        Task<bool> LoginUser(GetUserDTO userLogin);
    }
}