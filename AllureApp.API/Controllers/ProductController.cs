using AllureApp.Models;
using AllureApp.Service.Interface;
using AllureStore.Models;
using AllureStore.Service.Implementation;
using AllureStore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            var response = new ResponseModel<List<ProductModel>>();
            try
            {
                var result = _productService.GetAllProduct();
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

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var response = new ResponseModel<List<CategoryModel>>();
            try
            {
                var result = _productService.GetAllCategories();
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
        [HttpPost("InsertOrUpdateProduct")]
        public IActionResult InsertOrUpdateProduct(ProductModel model)
        {
            var response = new ResponseModel<int>();
            try
            {
                var result = _productService.InsertOrUpdateProduct(model);
                if (result == 1)
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
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetFrontPageProducts")]
        public IActionResult GetFrontPageProducts()
        {
            var response = new ResponseModel<List<ProductModel>>();
            try
            {
                var result = _productService.GetAllProduct();
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
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var result=_productService.DeleteProduct(productId);
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

