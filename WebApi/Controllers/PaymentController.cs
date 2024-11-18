using Core.DTOs.Card;
using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PaymentController : BaseApiController
    {

        private readonly IPaymentRepository _paymentRepository;

        private readonly IValidator<CreatePaymentDTO> _createPaymentValidation;

        public PaymentController(IPaymentRepository paymentRepository, IValidator<CreatePaymentDTO> createPaymentValidation)
        {
            _paymentRepository = paymentRepository;
            _createPaymentValidation = createPaymentValidation;
        }

        [HttpPost("/api/cards/{cardId}/payments")]

        public async Task<IActionResult> AddByCard(int cardId, CreatePaymentDTO createPaymentDTO)
        {
            var validation = await _createPaymentValidation.ValidateAsync(createPaymentDTO);
            if (!validation.IsValid) return BadRequest(validation.Errors);


            return Ok(await _paymentRepository.AddByCard(cardId, createPaymentDTO));


        }


    }
}
