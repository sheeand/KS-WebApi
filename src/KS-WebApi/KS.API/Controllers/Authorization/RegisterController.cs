using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KS.API.DataContract.Authorization;
using KS.Business.Managers.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KS.API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        // async Task<> is using best practice
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] NewUserCreateRequest userForResister)
        {
            userForResister.UserName = userForResister.UserName.ToLower();
            var registerManager = new RegisterUserManager();
            await registerManager.RegisterUser(userForResister);
            return StatusCode(201);
        }

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
