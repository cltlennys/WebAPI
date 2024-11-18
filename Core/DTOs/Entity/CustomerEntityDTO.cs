using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class CustomerEntityDTO
{
    public string EntityName { get; set; } = null!;
    public List<ProductDetailedDTO> Products { get; set; } = null!;
}
