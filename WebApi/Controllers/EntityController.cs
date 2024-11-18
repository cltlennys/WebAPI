using Core.DTOs.Entity;
using Core.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EntityController : BaseApiController
    {

        private readonly IEntityRepository _entityRepository;
        private readonly IValidator<CreateEntityDTO> _createEntityDTO;

        public EntityController(IEntityRepository entityRepository, IValidator<CreateEntityDTO> createEntityDTO)
        {
            _entityRepository = entityRepository;
            _createEntityDTO = createEntityDTO;
        }

        [HttpPost("/AddEntity")]

        public async Task<IActionResult> Add([FromBody] CreateEntityDTO createEntityDTO)
        {
            var validation = await _createEntityDTO.ValidateAsync(createEntityDTO);
            if (!validation.IsValid) return BadRequest(validation.Errors);
            return Ok(await _entityRepository.Add(createEntityDTO));
        }

        [HttpGet("/GetEntities/{customerid}")]

        public async Task<IActionResult> GetEntitiesProducts(int customerid)
        {
            return Ok(await _entityRepository.GetEntitiesProducts(customerid));
        }




    }
}
