using Core.DTOs.Charge;
using Core.DTOs.Entity;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping;

public class EntityMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateEntityDTO, Entity>();
        config.NewConfig<Entity, EntityDetailedDTO>();
    }
}
