using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Infrastructure.Validation.Customer;

namespace WebApi.Controllers
{
    public class CustomerEntityController : BaseApiController
    {
        private readonly ICustomerEntityRepository _repository;

        public CustomerEntityController(ICustomerEntityRepository repository)
        {
            _repository = repository;
        }

    }
}
