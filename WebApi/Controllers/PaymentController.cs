using Core.DTOs.Card;
using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PaymentController : BaseApiController
    {

        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost("/api/cards/{cardId}/payments")]

        public async Task<IActionResult> AddByCard(int cardId, CreatePaymentDTO createPaymentDTO)
        {
            return Ok(await _paymentRepository.AddByCard(cardId, createPaymentDTO));


        }


    }
}
