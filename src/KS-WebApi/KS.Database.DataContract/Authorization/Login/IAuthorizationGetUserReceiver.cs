using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Login.Commands
{
    public interface IAuthorizationGetUserReceiver
    {
        Task<bool> GetUserByUsername(GetUserRAO userRAO);
        Task<bool> LoginUser(UserLoginDTO userDTO);
    }
}