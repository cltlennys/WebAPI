

using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
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

        public async Task<CreateEntityDTO>


    }
}
