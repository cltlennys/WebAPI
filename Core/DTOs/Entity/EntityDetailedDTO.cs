namespace Core.DTOs.Entity
{
    public class EntityDetailedDTO
    { 
        public string CustomerName { get; set; } = string.Empty;
        public List<CustomerEntityDTO> Entities { get; set; } = null!;

    }
}
