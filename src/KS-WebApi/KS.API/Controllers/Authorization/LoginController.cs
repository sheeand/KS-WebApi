using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginUserManager _loginUserManager;
        private readonly IMapper _mapper;

        public LoginController(ILoginUserManager loginUserManager, IMapper mapper)
        {
            _loginUserManager = loginUserManager;
            _mapper = mapper;
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoggingIn)
        {
            _mapper.Map<UserLoginDTO>(userLoggingIn);

            userLoggingIn.UserName = userLoggingIn.UserName.ToLower();

            //-- Mapper maps UserLoginDTO to UserRegisterRAO
            var dto = _mapper.Map<UserLoginDTO>(userLoggingIn);

            await _loginUserManager.LoginUser(dto);
            return StatusCode(200);
        }


    }
}