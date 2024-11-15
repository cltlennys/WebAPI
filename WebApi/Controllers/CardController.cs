using Core.DTOs.Card;
using Core.DTOs.Customer;
using Core.DTOs.Transaction;
using Core.Entities;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly ICardRepository _cardRepository;

        private readonly ITransactionRepository _transactionRepository;

        private readonly IValidator<CreateCardDTO> _createValidation;
        private readonly IValidator<UpdateCardDTO> _updateValidation;

        public CardController(ICardRepository cardRepository, IValidator<CreateCardDTO> createValidation, IValidator<UpdateCardDTO> updateValidation, ITransactionRepository transactionRepository)
        {
            _cardRepository = cardRepository;
            _createValidation = createValidation;
            _updateValidation = updateValidation;
            _transactionRepository = transactionRepository;
        }

        [HttpGet("/Card/{CardId}")]

        public async Task<IActionResult> Get([FromRoute] int CardId)
        {
            return Ok(await _cardRepository.Get(CardId));
        }

        [HttpGet("/CardByCostumer/{customerId}")]

        public async Task<List<DetailedCardDTO>> GetByCustomer([FromRoute]int customerId)
        {
            return await _cardRepository.GetByCustomer(customerId);
        }

        


        [HttpPost("/Cards/Add")]

        public async Task<IActionResult> Add([FromBody]CreateCardDTO createCardDTO)
        {
            var validation = await _createValidation.ValidateAsync(createCardDTO);
            if (!validation.IsValid) 
            {
                return BadRequest(validation.Errors);
                    
            }
            return Ok(await _cardRepository.Add(createCardDTO));
        }

        [HttpGet("/{cardId}/transactions")]

        public async Task<IActionResult> GetTransaction([FromRoute]int cardId,[FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            return Ok(await _transactionRepository.GetTransaction( cardId, startDate, endDate));
        }

    }
}
