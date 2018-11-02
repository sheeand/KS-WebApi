using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//TODO: 8 - (CHALLENGE!) Call GTFU and capture the token string
//TODO: 9 - Change status code from created 201 to OK (token string, receive user)

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
            userLoggingIn.UserName = userLoggingIn.UserName.ToLower();

            var dto = _mapper.Map<GetUserDTO>(userLoggingIn);

            var receivedDTO = await _loginUserManager.LoginUser(dto);

            string tokenString = _loginUserManager.GenerateTokenForUser(receivedDTO);
            return Ok(new { tokenString, });

            //return StatusCode(200);
        }
    }
}