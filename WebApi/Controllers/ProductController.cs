using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProductController : BaseApiController
    {

        private readonly IProductRepository _productrepository;

        public ProductController(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }


        [HttpPost("/{EntityId}")]
        public async Task<IActionResult> Add(int EntityId, CreateProductDTO createProductDTO)
        {
            
            return Ok(await _productrepository.Add(EntityId, createProductDTO));
        }


    }
}
