

using Core.DTOs.Charge;
using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _repository;
        public EntityService(IEntityRepository repository)
        {
            _repository = repository;
        }


        public async Task<EntityDetailedDTO> Add(CreateEntityDTO createEntityDTO)
        {    
            return await _repository.Add(createEntityDTO);
        }


    }
}
