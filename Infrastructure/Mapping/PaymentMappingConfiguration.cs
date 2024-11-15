

using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Entities;
using Mapster;

namespace Infrastructure.Mapping
{
    public class PaymentMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePaymentDTO, Payment>()
                           .Map(dest => dest.Amount, src => src.Amount)
                           .Map(dest => dest.PaymentMethod, src => src.PaymentMethod)
                           .Map(dest => dest.Date, src => src.Date)
                           .Map(dest => dest.CardId, src => src.CardId);

            config.NewConfig<Payment, PaymentDTO>()
                           .Map(dest => dest.Amount, src => src.Amount) 
                           .Map(dest => dest.CardId, src => src.CardId) 
                           .Map(dest => dest.AvaibleCredit, src => src.AvaibleCredit)
                           .Map(dest => dest.Date, src => src.Date)
                           .Map(dest => dest.Debt, src => src.Card.CreditLimit - src.Card.AvailableCredit );



            
        }
    }
}
