

using Core.DTOs.Payment;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping
{
    public class CustomerEntityMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePaymentDTO, CustomerEntity>();





        }

    }
}
