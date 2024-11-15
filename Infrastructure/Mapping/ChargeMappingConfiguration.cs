using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class ChargeMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Charge, DetailedChargeDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CardId, src => src.CardId)
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.AvaibleCredit, src => src.AvaibleCredit)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Date, src => src.Date.ToShortDateString());

            config.NewConfig<Card, CardDTO>();
            config.NewConfig<CreateChargeDTO, Charge>()
                    .Map(dest => dest.Date, opt => DateTime.UtcNow);
            config.NewConfig<Charge, ChargeDTO>()
                    .Map(dest => dest.Date, src => src.Date.ToShortDateString())
                    .Map(dest => dest.Debt, src => src.Card.CreditLimit - src.Card.AvailableCredit);
        }




    }

    
}
