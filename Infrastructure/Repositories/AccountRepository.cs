using Core.DTOs.Account;
using Core.DTOs.Customer;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetailedAccountDTO> GetById(int id)
        {
            var entity = await _context.Accounts
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) throw new Exception("No se encontro la cuenta con el id solicitado");

            var dtos = new DetailedAccountDTO
            {
                Id = entity.Id,
                Number = entity.Number,
                Balance = entity.Balance,
                OpeningDate = entity.OpeningDate.ToShortDateString(),
                Customer = new CustomerDTO
                {
                    Id = entity.Customer.Id,
                    FullName = $"{entity.Customer.FirstName} + {entity.Customer.LastName}",
                    Email = entity.Customer.Email,
                    Phone = entity.Customer.Phone, 
                    BirthDate = entity.Customer.BirthDate

                }
              
            };

            return entity.Adapt<DetailedAccountDTO>() ;


        }


    }
}
