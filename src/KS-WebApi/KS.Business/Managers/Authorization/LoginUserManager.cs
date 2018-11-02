using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
using KS.Database.DataContract.Authorization.Login;
using KS.Database.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class LoginUserManager : ILoginUserManager
    {
        //TODO: 2 - Generate token for user method
        //TODO: 3 - Add (inject) IConfigurationManager param to constructor and create read-only field
        //TODO: 4 - Add GenerateTokenEngine class (provided by Paul on Slack)
        //TODO: 5 - Inside of GenerateToken, create new instance of GenerateToken Engine
        //TODO: 6 - GenerateTokenForUser method should return a token string

        //TODO: 0.6 Fix implementation
        //TODO: 0.7 In LoginUser method new-up password engine and if true then map Received RAO to a DTO

        private readonly IUserLoginInvoker _userLoginInvoker;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginUserManager(IUserLoginInvoker userLoginInvoker, IConfiguration configuration, IMapper mapper)
        {
            _userLoginInvoker = userLoginInvoker;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ReceivedUserLoginDTO> LoginUser(GetUserDTO incomingLoginDTO)
        {
            var hashChecker = new VerifyPasswordHashEngine();

            var receivedUser = await _userLoginInvoker.InvokeLoginUserCommand(_mapper.Map<GetUserRAO>(incomingLoginDTO)); 

            if (hashChecker.VerifyPasswordHash(incomingLoginDTO.Password, receivedUser.PasswordHash, receivedUser.PasswordSalt))
            {
                return _mapper.Map<ReceivedUserLoginDTO>(receivedUser);
            }
            return null;
        }

        public string GenerateTokenForUser(ReceivedUserLoginDTO receivedUserLoginDTO)
        {
            var tokenEngine = new GenerateTokenEngine(_configuration);
            string tokenString = tokenEngine.GenerateTokenString(receivedUserLoginDTO);
            return tokenString;
        }
    }
}
