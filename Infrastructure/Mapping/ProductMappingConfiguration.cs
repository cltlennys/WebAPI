using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class ProductMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductDTO, Product>();
            config.NewConfig<Product, ProductDetailedDTO>();

           
        }
    }
}
