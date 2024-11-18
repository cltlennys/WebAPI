

using Core.DTOs.Entity;

namespace Core.Interfaces.Repositories
{
    public interface IEntityRepository
    {

        Task<EntityDetailedDTO> Add(CreateEntityDTO createEntityDTO);

        Task<bool> VerifyExist(int CustomerId);

        Task<EntityDetailedDTO> GetEntitiesProducts(int id);


    }
}
