using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validation.Customer;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ChargeController : BaseApiController
    {

        
            private readonly IChargeRepository _chargeRepository;

        private readonly ITransactionRepository _transactionRepository;

        private readonly IValidator<CreateChargeDTO> _createValidation;

            public ChargeController(IChargeRepository chargeRepository, ITransactionRepository transactionRepository, IValidator<CreateChargeDTO> createValidation)
            {
                _chargeRepository = chargeRepository;
                _transactionRepository = transactionRepository;
                _createValidation = createValidation;   
            }

        [HttpPost("/Card/{cardId}/Charges")]

        public async Task<IActionResult> AddByCard([FromRoute]int cardId, [FromBody] CreateChargeDTO createChargeDTO)
        {
            var validation = await _createValidation.ValidateAsync(createChargeDTO);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);

            }
            return Ok(await _chargeRepository.AddByCard(cardId, createChargeDTO));
        }

        





    }
}
