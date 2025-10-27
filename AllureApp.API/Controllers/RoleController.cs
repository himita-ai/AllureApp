using AllureApp.Models;
using AllureStore.Models;
using AllureStore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        private ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var response = new ResponseModel<List<AdminRoleModel>>();
            try
            {
                var result = _roleService.GetAllRoles().ToList();
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
        [HttpPost]
        public IActionResult InsertOrUpdateRole(AdminRoleModel model)
        {
            var response = new ResponseModel<AdminRoleModel>();
            try
            {
                var result = _roleService.InsertOrUpdateRole(model);
                if (result == 1)
                {
                    response.Success = true;
                    response.Status = "ok";
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