using AutoMapper;
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
        private readonly IMapper mapper; // mapping

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(ProductDto product)
        {
            var productDtoMapped = mapper.Map<Product>(product);
            productService.Add(productDtoMapped);
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
            var productDtoMapped = mapper.Map<Product>(product);
            productService.Update(productDtoMapped);
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
