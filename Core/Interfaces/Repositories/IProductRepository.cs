using Core.DTOs.Product;

namespace Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductDetailedDTO> Add(int EntityId, CreateProductDTO createProductDTO);
        Task<bool> VerifyExist(int entityId);
    }
}
