using Core.DTOs.Card;
using Core.DTOs.Charge;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validation.Charge
{
    public class CreateChargeValidation : AbstractValidator<CreateChargeDTO>
    {

        public CreateChargeValidation()
        {
            RuleFor(c => c.Amount).NotEmpty();
            RuleFor(c => c.CardId).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }
    }
}
