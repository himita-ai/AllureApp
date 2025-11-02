using AllureApp.Models;
using AllureApp.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private I_ImageService _imageService;
      private ILogger<ImageController> _logger;
        public ImageController(I_ImageService imageService, ILogger<ImageController> logger)
        {
            _imageService = imageService;
          _logger = logger;
        }
        [HttpPost("SaveImage")]
        public IActionResult SaveImage(IFormFile file, int productId)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var result = _imageService.SaveImage(file, productId);
                if (result)
                {
                    response.Success = true;
                    response.Status = "ok";
                    
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Status = "Failed";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
              _logger.LogError(ex, "Error saving image");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
