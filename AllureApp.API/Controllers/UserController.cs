using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Service.Interface;
using AllureStore.Models;
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
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
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
        [HttpGet("VerifyUser")]
        public IActionResult VerifyUser(string email, string password)
        {
            try
            {
                var response = new ResponseModel<string>();
                var result = _userService.VerifyUser(email, password);
                if (result.Id > 0)
                {
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, result.Email),
                        new Claim(ClaimTypes.NameIdentifier, result.FirstName),
                         new Claim(ClaimTypes.Role, result.RoleName)

                    };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
                    var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var secToken = new JwtSecurityToken(_config["Jwt:Issuer"],
                        claims: claim,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credential,
                          audience: _config["Jwt:Audience"]

                        );

                    var token = new JwtSecurityTokenHandler().WriteToken(secToken);

                    response.Success = true;
                    response.Status = "ok";
                    response.Result = token;
                }
                else
                {
                    response.Success = false;
                    response.Status = "Failed";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllUsers")]
       
        public IActionResult GetAllUsers()
        {
           

            try
            {
                var response = new ResponseModel<List<UserModel>>();
                var result = _userService.GetAllUsers().ToList();
                if (result.Any())
                {
                    response.Success = true;
                    response.Status = "ok";
                    response.Result = result;
                }
                else
                {
                    response.Success = false;
                    response.Status = "Failed";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAdminNavItems")]
        public IActionResult GetAdminNavItems()
        {
            try
            {
                var response = new ResponseModel<List<AdminNavItemModel>>();
                var items = _userService.GetAdminNavItems().ToList();
                if (items.Any())
                {
                    response.Success = true;
                    response.Status = "Ok";
                    response.Result = items;
                }
                else
                {
                    response.Success = false;
                    response.Status = "Failed";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AssignRoleToUser")]
        public IActionResult AssignRoleToUser(AssignRoleModel model)
        {
            try
            {
                var response = new ResponseModel<User>();
                var result = _userService.AssignRoleToUsers(model);
                if (result)
                {
                    response.Success = true;
                    response.Status = "Ok";
                }
                else
                {
                    response.Success = false;
                    response.Status = "Failed";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    



