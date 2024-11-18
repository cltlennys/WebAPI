

using Core.DTOs;
using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
namespace Infrastructure.Services;
public class CardService : ICardService
{
    private readonly ICardRepository _repository;

    private readonly IChargeRepository _chargeRepository;
    public CardService(ICardRepository repository, IChargeRepository chargeRepository)
    {
        _repository = repository;
        _chargeRepository = chargeRepository;
    }
    public async Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO)
    {
        return await _repository.Add(createCardDTO);
    }

    public async Task<ChargeDTO> AddByCard(int cardId, CreateChargeDTO createChargeDTO)
    {
        var isTransactionAllowed = await _chargeRepository
            .VerifyChargeAmount(createChargeDTO.CardId, createChargeDTO.Amount);

        if (!isTransactionAllowed)
            throw new Exception("El monto supera el limite");
        return await _chargeRepository.AddByCard(cardId, createChargeDTO);
    }
}
