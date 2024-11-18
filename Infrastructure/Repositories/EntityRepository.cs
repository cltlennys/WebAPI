using Core.DTOs.Charge;
using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository

    {

        private readonly ApplicationDbContext _context;
        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EntityDetailedDTO> Add( CreateEntityDTO createEntityDTO)
        {
            //var entity = await _context.Entities.FindAsync(CustomerId);
            //if (entity == null)  throw new Exception("No se ha encontrado al cliente");

            var create = createEntityDTO.Adapt<Entity>();

            _context.Entities.Add(create);
            await _context.SaveChangesAsync();

            return create.Adapt<EntityDetailedDTO>();

        }

        public async Task<CreateEntityDTO> Update(int CustomerId, CreateEntityDTO createEntityDTO)
        {

            var create = createEntityDTO.Adapt<Entity>();

            _context.Entities.Update(create);
            await _context.SaveChangesAsync();

            return create.Adapt<CreateEntityDTO>();

        }

        public async Task<CreateEntityDTO> Delete(int CustomerId, CreateEntityDTO createEntityDTO)
        {
            var entity = await _context.Entities.FindAsync(CustomerId);
            if (entity == null) throw new Exception("No se ha encontrado al cliente");

            var create = createEntityDTO.Adapt<Entity>();

            _context.Entities.Remove(create);
            await _context.SaveChangesAsync();

            return create.Adapt<CreateEntityDTO>();

        }

        public async Task<EntityDetailedDTO> GetEntitiesProducts(int id)
        {
            var customer = await _context.CustomerProducts
                .Include(x => x.CustomerEntity)
                .ThenInclude(x => x.Customer)
                .Include(x => x.CustomerEntity)
                .ThenInclude(x => x.Entity)
                .Include(x => x.Product)
                .ThenInclude(x => x.Entity)
                .Where(x => x.CustomerEntity.Customer.Id == id).ToListAsync();
            if (customer == null) throw new Exception("No se ha encontrado el cliente");
            var response = new EntityDetailedDTO
            {
                CustomerName = customer.FirstOrDefault()?.CustomerEntity.Customer.FirstName ?? "No se encontro el cliente",
                Entities = customer
                            .GroupBy(x => x.CustomerEntity)
                            .Select(x => new CustomerEntityDTO
                            {
                                EntityName = x.First().CustomerEntity.Entity.EntityName,
                                Products = x.Select(p => new ProductDetailedDTO
                                {
                                    Name = p.Product.Name,
                                    Status = p.Product.Status,
                                    Description = p.Product.Description,
                                    StartDate = p.Product.StartDate
                                }).ToList()
                            }) .ToList()
                
            };
            return response;
        }

        public async Task<bool> VerifyExist(int cardId)
        {
            var card = await _context.Cards.FindAsync(cardId);
            if (card is null)
                throw new Exception("No se encont");
            return true;


        }
    }
}
