using Core.DTOs.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validation.Entity
{
    public class CreateEntityValidation : AbstractValidator<CreateEntityDTO>
    {

        public CreateEntityValidation()
        {
            RuleFor(c => c.EntityName).NotEmpty();
            RuleFor(c => c.CustomerId).GreaterThan(0);
        }

    }
}

   

