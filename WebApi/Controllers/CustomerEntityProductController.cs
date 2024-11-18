using Core.Interfaces.Repositories;

namespace WebApi.Controllers
{
    public class CustomerEntityProductController : BaseApiController
    {
        private readonly ICustomerEntityProductRepository _repository;

        public CustomerEntityProductController(ICustomerEntityProductRepository repository)
        {
            _repository = repository;
        }
    }
}
