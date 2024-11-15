

using Core.DTOs.Card;
using FluentValidation;

namespace Infrastructure.Validation.Card
{
    public class UpdateCardValidation : AbstractValidator<UpdateCardDTO>
    {
        public UpdateCardValidation()
        {

            RuleFor(c => c.CreditLimit).Empty();

            RuleFor(c => c.Number).Empty().Length(1,16);

            RuleFor(c => c.AvailableCredit).Empty();

            RuleFor(c => c.Status).Empty();

            RuleFor(c => c.InteresRate).Empty();

            RuleFor(c => c.ExpirationDate).NotEmpty();




        }
    }
}
