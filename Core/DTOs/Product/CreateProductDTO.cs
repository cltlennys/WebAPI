namespace Core.DTOs.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
    }
}
