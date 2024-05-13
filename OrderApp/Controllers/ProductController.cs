using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Dtos;

using Order.Application.Interface.IServices;
using Order.Infrastructure.Services;
using OrderApp.Middleware;

namespace OrderApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ProductController : ControllerBase
    {

        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;  
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productModel)
        {

           
                if (productModel == null)
                    throw new BadRequestException("Product is not passed");
                await _productService.ICreateProduct(productModel);
              
                return Ok(new
                {
                    Message = "Product added successfully."
                });
           
        }

        [HttpGet("products")]
        public async Task<IActionResult> DisplayProducts()
        {

                          
              var list=  await _productService.IDisplayProducts();
              if(list.Count==0)
                throw new NotFoundException("Product not found.");

                return Ok(list);
           
        }
    }
}
