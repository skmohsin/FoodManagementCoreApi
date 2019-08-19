using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodManagementCore.Models;
using FoodManagementCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        // GET api/user
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<User>> Get()
        {
            IEnumerable<User> users = _userService.GetUser();
            if (users.Count() != 0)
                return Ok(new { data = users, message = "Success", status = true });
            return Ok(new { data = users, message = "No data available", status = true });
        }

        // POST api/user
        [HttpPost]
        public ActionResult<User> Authenticate(User user)
        {
            var jwtToken = _userService.Authenticate(user);
            if (jwtToken == null)
            {
                return Unauthorized();
            }
            return Ok(new { data = jwtToken, message = "Login succeeded", status = true });
        }
    }
}