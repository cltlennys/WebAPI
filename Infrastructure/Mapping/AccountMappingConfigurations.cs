using Core.DTOs.Account;
using Core.DTOs.Customer;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping
{
    public class AccountMappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Account, DetailedAccountDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Number, src => src.Number)
                .Map(dest => dest.Balance, src => src.Balance)
                .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString())
                .Map(dest => dest.Customer, src => src.Adapt<DetailedCustomerDTO>());
        }

    }
}
