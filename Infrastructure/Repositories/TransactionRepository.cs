

using Core.DTOs.Transaction;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionDTO>> GetTransaction(int cardId, DateTime startDate, DateTime endDate)
        {
            var card = await _context.Cards
                .Include(x => x.Payments)
                .Include(x => x.Charges)
                .FirstOrDefaultAsync(x => x.Id == cardId)
                ?? throw new Exception("No se encontro la tarjeta");

            var payments = card.Payments.Select(x => new TransactionDTO
            {
                Type = "Payment",
                Amount = x.Amount,
                TransactionDate = x.Date,
                Description = "Pago Recibido"
            }).ToList();

            var charges = card.Charges.Select(x => new TransactionDTO
            {
                Type = "Charge",
                Amount = x.Amount,
                TransactionDate = x.Date,
                Description = x.Description
            }).ToList();

            var startDateValue = startDate;
            var endDateValue = endDate;
            

            return payments.Concat(charges)
                .OrderByDescending(x => x.TransactionDate)
                .Where(x => x.TransactionDate >= startDateValue && x.TransactionDate <= endDateValue )
                .ToList();
        }


    }
}
