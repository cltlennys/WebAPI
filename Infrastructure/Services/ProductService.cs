using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService
    {

        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<ProductDetailedDTO> Add(int EntityId, CreateProductDTO createProductDTO)
        {
            var isTransactionAllowed = await _repository
           .VerifyExist(EntityId);

            if (!isTransactionAllowed)
                throw new Exception("No se encontro el cliente");
            return await _repository.Add(EntityId, createProductDTO);
        }


    }
}
