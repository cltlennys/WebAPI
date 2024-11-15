

using Core.DTOs.Card;
using Core.DTOs.Customer;
using FluentValidation;

namespace Infrastructure.Validation.Card
{
    public class CreateCardValidation : AbstractValidator<CreateCardDTO>
    {
        public CreateCardValidation()
        {

            RuleFor(c => c.CreditLimit).NotEmpty();



            RuleFor(c => c.Status).NotEmpty();

            RuleFor(c => c.InteresRate).NotEmpty();

            RuleFor(c => c.ExpirationDate).NotEmpty();




        }
    }
}
