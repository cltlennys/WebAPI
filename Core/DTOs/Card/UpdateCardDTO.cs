

namespace Core.DTOs.Card
{
    public class UpdateCardDTO
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int CreditLimit { get; set; }

        public int AvailableCredit { get; set; }

        public decimal InteresRate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
