using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult Post(ProductDto product)
        {
            var productDto = new Product
            {
                Name = product.Name,
                Category = product.Category,
                Barcode = product.Barcode
            };
            productService.Add(productDto);
            return Ok();
        }

        [HttpGet("Products")]
        public IActionResult Get()
        {
            var result = productService.GetAll();
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            productService.Update(product);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Product product)
        {
            productService.HardDelete(product);
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            productService.GetById(id);
            return Ok();
        }

    }
}
