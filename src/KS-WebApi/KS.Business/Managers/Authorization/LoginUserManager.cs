using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class LoginUserManager : ILoginUserManager
    {
        ///TODO GetUserByUser-Password
        ///TODO Return 200

        private readonly IUserLoginInvoker _userLoginInvoker;
        private readonly IGetUserInvoker _getUserInvoker;
        private readonly IMapper _mapper;

        public LoginUserManager(IUserLoginInvoker userLoginInvoker, IGetUserInvoker getUserInvoker, IMapper mapper)
        {
            _userLoginInvoker = userLoginInvoker;
            _getUserInvoker = getUserInvoker;
            _mapper = mapper;
        }

        public LoginUserManager()
        {
        }

        public async Task<bool> LoginUser(UserLoginDTO loginDTO)
        {
            var rao = PrepareUserRAOForLogin(loginDTO);

            if (rao.Password.Length > 0)
            {
                return await _userLoginInvoker.InvokeLoginUserCommand(rao);
            }
            else
            {
                return false;
            }
        }

        // helper method
        private UserLoginRAO PrepareUserRAOForLogin(UserLoginDTO userDTO)
        {

            byte[] passwordHash, passwordSalt;

            //-- Create an instance of the engine
            var hashEngine = new CreatePasswordHashEngine();

            //-- Pass userDTO variable into CreatePasswordHash method to hash the password
            hashEngine.CreatePaswordHash(userDTO.Password, out passwordHash, out passwordSalt);

            UserLoginRAO rao = new UserLoginRAO();

            var verifyEngine = new VerifyPasswordHashEngine();

            bool isValid = verifyEngine.VerifyPasswordHash(userDTO.Password, passwordHash, passwordSalt);

            if (isValid)
            {
                rao.Password = userDTO.Password;
                rao.Username = userDTO.Username;
                //rao = _mapper.Map<UserLoginRAO>(userDTO);
            }

            //verifyEngine.VerifyPasswordHash(userDTO.Password, passwordHash, passwordSalt);


            return rao;
        }

        //public Task<bool> LoginUser(NewUserCreateDTO userLogin)
        //{
        //    var rao = PrepareUserRAOForRegister(userDTO);

        //    return await _userRegisterInvoker.InvokeRegisterUserCommand(rao);
        //}
    }
}
