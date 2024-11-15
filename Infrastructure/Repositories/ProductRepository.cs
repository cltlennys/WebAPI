﻿

using Core.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
