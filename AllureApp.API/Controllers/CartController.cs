using AllureApp.Models;
using AllureApp.Service.Interface;
using AllureStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        private ILogger<CartController> _logger;
        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }
        [HttpGet("GetCart")]
        public IActionResult GetCart (int UserId)
        {
            var response = new ResponseModel<List<CartItemModel>>();
            try
            {
                var result = _cartService.GetCart(UserId).ToList();
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
        [HttpPost("AddToCart")]
        public IActionResult AddToCart( CartItemModel model)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var result = _cartService.AddToCart(model);
                response.Success = result;
                response.Status = result ? "ok" : "failed";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("IncreaseQuantity")]
        public IActionResult IncreaseQuantity(int Id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var result = _cartService.UpdateCartItemQuantity(Id, 1); // +1
                response.Success = result;
                response.Status = result ? "ok" : "failed";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("DecreaseQuantity")]
        public IActionResult DecreaseQuantity(int Id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var result = _cartService.UpdateCartItemQuantity(Id, -1); // -1
                response.Success = result;
                response.Status = result ? "ok" : "failed";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteItem")]
        public IActionResult DeleteItem(int Id)
        { 
            var response = new ResponseModel<bool>();
            try
            {
                var result = _cartService.DeleteItem(Id);
                if (result)
                {
                    return Ok(result);
                }
                return NotFound();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    
}
