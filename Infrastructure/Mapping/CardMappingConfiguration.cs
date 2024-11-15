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
    public class CardMappingConfiguration : IRegister
    {



        public static string GenerateRandomCardNumbers()
        {
            var random = new Random();
            string number = "";

            for (int i = 0; i < 12; i++)
            {
                number += random.Next(0, 10);
            }

            return number;
        }

        public void Register(TypeAdapterConfig config)
        {
            var random = new Random();

            config.NewConfig<CreateCardDTO, Card>()
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.Type, src => src.Type)
                .Map(dest => dest.CreditLimit, src => src.CreditLimit)
                .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
                .Map(dest => dest.InteresRate, src => src.InteresRate)
                .Map(dest => dest.AvailableCredit, src => src.CreditLimit)
                .Map(dest => dest.Status, src => "active")
                .Map(dest => dest.Number, src => GetCardNumber());


            //config.NewConfig<Card, CreateCardDTO>()
            //    .Map(dest => dest.CustomerId, src => src.CustomerId)
            //    .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            //    .Map(dest => dest.InteresRate, src => src.InteresRate)
            //    //.Map(dest => dest.AvailableCredit, src => random.Next(100, 100000))
            //    .Map(dest => dest.Status, src => src.Status)
            //    //.Map(dest => dest.Number, src => GetCardNumber())
            //    .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);

            config.NewConfig<Card, DetailedCardDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.CreditLimit, src => src.CreditLimit)
                .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
                .Map(dest => dest.InteresRate, src => src.InteresRate)
                .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
                .Map(dest => dest.Number, src => $"XXXX-XXXX-XXXX-{src.Number.Substring(src.Number.Length - 4, 4)}")
                .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);


            config.NewConfig<Charge, ChargeDTO>()
                .Map(dest => dest.Id, src => src.Id)
                //.Map(dest => dest.CardId, src => src.CardId)
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.AvaibleCredit, src => src.AvaibleCredit)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Date, src => src.Date.ToShortDateString());
            config.NewConfig<Card, CardDTO>()
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.CreditLimit, src => src.CreditLimit)
                .Map(dest => dest.InteresRate, src => src.InteresRate)
                .Map(dest => dest.AvailableCredit, src => random.Next(100, 100000))
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Number, src => GetCardNumber())
                .Map(dest => dest.ExpirationDate, src => src.ExpirationDate);
            config.NewConfig<CreateChargeDTO, Charge>()
                    .Map(dest => dest.Date, opt => DateTime.UtcNow);
            config.NewConfig<Charge, ChargeDTO>()
                    .Map(dest => dest.Date, src => src.Date.ToShortDateString())
                    .Map(dest => dest.Debt, src => src.Card.CreditLimit - src.Card.AvailableCredit);
        }



        private string MaskCardNumber(string cardNumber)
        {

            { if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4) return cardNumber;

                return new string('X', cardNumber.Length - 4) + cardNumber.Substring(cardNumber.Length - 4);
            }

        }

        private static string GetCardNumber()
        {
            var random = new Random();
            List<string> CardNumber = [];
            for (int i = 0; i < 4; i++)
            {

                CardNumber.Add(random.Next(1000, 1000).ToString());

            }
            return string.Join('-', CardNumber);
        }
    }

}






