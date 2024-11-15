

using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChargeRepository : IChargeRepository
    {


        private readonly ApplicationDbContext _context;

        public ChargeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChargeDTO> AddByCard(int cardId, CreateChargeDTO createChargeDTO)
        {

            var entity = await _context.Cards.FindAsync(cardId);
            var charge = createChargeDTO.Adapt<Charge>();
            

            charge.AvaibleCredit = entity!.AvailableCredit - createChargeDTO.Amount;
            entity.AvailableCredit = entity!.AvailableCredit - createChargeDTO.Amount;

            _context.Charges.Add(charge);
            await _context.SaveChangesAsync();

            return charge.Adapt<ChargeDTO>();
        }

        public async Task<bool> VerifyChargeAmount(int cardId, int amount)
        {
            var card = await _context.Cards.FindAsync(cardId);
            if (card is null)
                throw new Exception("No se encont");
            return card.CreditLimit - card.AvailableCredit >= amount;
        }

        public async Task<List<ChargeDTO>> GetAll()
        {
            //return await _}
            throw new Exception();
        }
            
    }
}
