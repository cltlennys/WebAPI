using Core.DTOs.Charge;
using Core.DTOs.Payment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validation.Payment
{
    public class CreatePaymentValidation : AbstractValidator<CreatePaymentDTO>
    {
        public CreatePaymentValidation()
        {
            RuleFor(c => c.Amount).NotEmpty();
            RuleFor(c => c.CardId).GreaterThan(0);
            RuleFor(c => c.PaymentMethod).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }


    }
}
