using Core.DTOs.Card;

namespace Core.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Task<DetailedCardDTO> Get(int CardId);
        Task<List<DetailedCardDTO>> GetByCustomer(int customerId);

        Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO);
        Task<CardDTO> Update(UpdateCardDTO updateCardDTO, int id);

    }
}
