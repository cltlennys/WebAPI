

using Core.DTOs.Entity;

namespace Core.Interfaces.Services
{
    public interface IEntityService
    {

        Task<EntityDetailedDTO> Add( CreateEntityDTO createEntityDTO);


    }
}
