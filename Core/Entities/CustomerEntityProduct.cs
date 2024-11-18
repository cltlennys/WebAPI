

namespace Core.Entities;

public class CustomerEntityProduct
{
    public int Id { get; set; }
    public int CustomerEntityId {  get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public CustomerEntity CustomerEntity { get; set; } = null!;

}
