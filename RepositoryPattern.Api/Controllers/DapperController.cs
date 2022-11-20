using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Data.Concretes;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Concretes;
using RepositoryPattern.Services.DTOs;
using System.Threading.Tasks;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {        
        private readonly IUnitOfWork unitOfWork;
        public DapperController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Products.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Products.GetById(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product entity)
        {
            var data = await unitOfWork.Products.DapperAdd(entity);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Products.DapperDelete(id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product entity)
        {
            var data = await unitOfWork.Products.DapperUpdate(entity);
            return Ok(data);
        }
    }
}
