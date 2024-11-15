

using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentDTO> AddByCard(int cardId, CreatePaymentDTO createPaymentDTO)
        {

            var card = await _context.Cards.FindAsync(cardId);

            

            if (card == null) throw new Exception("No se encontro el id de la tarjeta");

            
            var payment = createPaymentDTO.Adapt<Payment>();

            payment.AvaibleCredit = card!.AvailableCredit > createPaymentDTO.Amount ? card!.AvailableCredit + createPaymentDTO.Amount :
                throw new Exception(" El pago que desea realizar es mayor al credito debido");
            card.AvailableCredit = card!.AvailableCredit > createPaymentDTO.Amount ? card!.AvailableCredit + createPaymentDTO.Amount :
                throw new Exception(" El pago que desea realizar es mayor al credito debido");
            payment.AvaibleCredit = card.AvailableCredit;


            //var payment = new Payment
            //{
            //    CardId = cardId,
            //    Amount = createPaymentDTO.Amount,
            //    PaymentMethod = createPaymentDTO.PaymentMethod,
            //    Date = createPaymentDTO.Date,
            //};



            //var dto = new PaymentDTO()
            //{
            //    Id = payment.Id,
            //    CardId = cardId,
            //    Amount = payment.Amount,
            //    PaymentMethod = payment.PaymentMethod,
            //    AvaibleCredit = NewAvaibleCredit,
            //    Date = payment.Date,


            //};

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return payment.Adapt<PaymentDTO>();
        }

    }
}
