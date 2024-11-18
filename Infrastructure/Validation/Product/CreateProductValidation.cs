using Core.DTOs.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validation.Product
{
    public class CreateProductValidation : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.StartDate).NotEmpty();
        }

    }
}
