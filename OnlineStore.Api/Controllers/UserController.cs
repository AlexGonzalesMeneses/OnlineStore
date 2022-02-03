using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Services;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private ILoggerManager loggerManager;

        public UserController(IUserService userService, ILoggerManager loggerManager)
        {
            this.userService = userService;
            this.loggerManager = loggerManager;
        }

        // GET: api/<userController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get users");
            }
        }

        [HttpGet("search")]

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var user = userService.GetById(id);
                return user.Id == Guid.Empty ? (IActionResult)NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get user");
            }
        }

        // POST api/<userController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                var existinguser = userService.GetById(user.Id);

                if (existinguser.Id != Guid.Empty)
                {
                    return BadRequest("user already exists");
                }

                var newuser = userService.Add(user);

                return Ok(newuser);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to add user");
            }
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User user)
        {
            try
            {
                var updateduser = userService.GetById(id);

                if (updateduser.Id == Guid.Empty)
                {
                    return NotFound("user not exists");
                }

                updateduser.Username = user.Username;
                updateduser.Email = user.Email;
                updateduser.Password = user.Password;

                return Ok(userService.Update(updateduser));
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to update user");
            }
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var user = userService.GetById(id);

                if (user.Id == Guid.Empty)
                {
                    return NotFound("user not exists");
                }

                userService.Delete(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to delete user");
            }
        }
    }
}
