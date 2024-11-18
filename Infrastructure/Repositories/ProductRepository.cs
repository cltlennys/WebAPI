

using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDetailedDTO> Add(int EntityId, CreateProductDTO createProductDTO)
        {
            var create = createProductDTO.Adapt<Product>();
            _context.Products.Add(create);
            await _context.SaveChangesAsync();
            return create.Adapt<ProductDetailedDTO>();
        }

        public async Task<bool> VerifyExist(int EntityId)
        {
            var card = await _context.Products.FindAsync(EntityId);
            if (card is null)
                throw new Exception("No se encontro la entidad");
            return true;
        }


    }
}
