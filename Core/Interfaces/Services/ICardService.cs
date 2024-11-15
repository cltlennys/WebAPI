

using Core.DTOs.Card;
using Core.DTOs.Charge;

namespace Core.Interfaces.Services
{
    public interface ICardService
    {
        Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO);

        Task<ChargeDTO> AddByCard(int cardId, CreateChargeDTO createChargeDTO);

       



    }
}
