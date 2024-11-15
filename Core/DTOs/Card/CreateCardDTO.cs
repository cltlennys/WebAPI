

namespace Core.DTOs.Card
{
    public class CreateCardDTO
    {

        public string Type { get; set; } = string.Empty;

        public int CustomerId { get; set; } 
        public int CreditLimit { get; set; }


        public decimal InteresRate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Status { get; set; } = string.Empty;

    }
}
