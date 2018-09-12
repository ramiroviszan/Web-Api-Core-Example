using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAC.WebAPI.Models;
using WAC.Contracts.Application.Users;
using WAC.Domain.Users;

namespace WAC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService aUserService) {
            userService = aUserService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetById")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UserModelIn userIn)
        {
            if(ModelState.IsValid) {
                var user = new User(userIn.Username, userIn.Password, userIn.Age);
                userService.SignUp(user);
                var addedUser = new UserModelOut() { Id = user.Id, Username = userIn.Username, Age = userIn.Age };
                return CreatedAtRoute("GetById", new { id = addedUser.Id }, addedUser);
            } else {
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
