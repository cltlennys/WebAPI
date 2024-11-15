using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ChargeController : BaseApiController
    {

        
            private readonly IChargeRepository _chargeRepository;

            public ChargeController(IChargeRepository chargeRepository)
            {
                _chargeRepository = chargeRepository;
            }

        [HttpPost("/Card/{cardId}/Charges")]

        public async Task<ChargeDTO> AddByCard([FromRoute]int cardId, [FromBody] CreateChargeDTO createChargeDTO)
        {
            
            return await _chargeRepository.AddByCard(cardId, createChargeDTO);
        }

        [HttpGet("/getall")]

        public async Task<List<ChargeDTO>> GetAll()
        {
            //return await 
            throw new Exception();
        }





    }
}
