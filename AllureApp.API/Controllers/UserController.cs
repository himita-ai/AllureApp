using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("InsertOrUpdateUser")]
        public IActionResult InsertOrUpdateUser([FromBody] UserModel model)
        {
            try
            {
                var response = _userService.InsertOrUpdateUser(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<User>
                {
                    Success = false,
                    Status = "Exception: " + ex.Message,
                    Result = null
                });
            }
        }
    }
}


