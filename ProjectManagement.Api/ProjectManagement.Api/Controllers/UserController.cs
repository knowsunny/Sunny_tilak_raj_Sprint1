using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : BaseController<User>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            if (id > 0)
            {
                var user = _userService.GetUserByUserId(id);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var isUserCreationSuccessful = await _userService.Create(user);

            return Ok(isUserCreationSuccessful);
        } 

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var isUserUpdationSuccessful = await _userService.Update(user);

            return Ok(isUserUpdationSuccessful);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("authenticate")]
        public IActionResult UserLogin(User user)
        {
            var isAuthenticated = _userService.UserLogin(user);
            return Ok(isAuthenticated);
        }
    }
}
