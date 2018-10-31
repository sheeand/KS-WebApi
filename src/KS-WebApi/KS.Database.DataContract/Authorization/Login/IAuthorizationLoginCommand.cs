using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KS.Business.DataContract.Authorization;

namespace KS.Database.DataContract.Authorization.Login
{
    public interface IAuthorizationLoginCommand
    {
        Task<bool> Execute(UserLoginRAO userDTO);
    }
}
