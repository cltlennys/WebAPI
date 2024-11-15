

using Core.DTOs;
using Core.DTOs.Card;
using Core.DTOs.Customer;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DetailedCardDTO>> GetByCustomer (int customerId)
        {

            var entity = await _context.Customers.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == customerId);

            if (entity == null) throw new Exception("No se encontro al cliente");

            return entity.Cards.Adapt<List<DetailedCardDTO>>();
        }

        public async Task<DetailedCardDTO> Get (int CardId)
        {
            var entity = await _context.Cards
           .Include(x => x.Customer)
           .FirstOrDefaultAsync(x => x.Id == CardId);
            if (entity == null) throw new Exception("No se encontro con el id solicitado");

            return entity.Adapt<DetailedCardDTO>();
        }

        public async Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO)
        {
            
            
                var entity = createCardDTO.Adapt<Card>();

                _context.Cards.Add(entity); //aqui no impactamos aun la BD
                await _context.SaveChangesAsync(); //esto impacta en la BD



                return entity.Adapt<DetailedCardDTO>();
            
        }

        public async Task<CardDTO> Update(UpdateCardDTO updateCardDTO, int id)
        {
            var entity = await VerifyExists(id);

            updateCardDTO.Adapt(entity);

            _context.Cards.Update(entity);
            await _context.SaveChangesAsync();


            return entity.Adapt<CardDTO>();
        }
        private async Task<Card> VerifyExists(int id)
        {
            var entity = await _context.Cards.FindAsync(id);
            if (entity == null) throw new Exception("No se encontro con el id solicitado");
            return entity;
        }

        

    }
}
