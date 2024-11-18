using Core.DTOs.CustomerEntity;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerEntityRepository : ICustomerEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerEntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

    }
}
