

namespace Core.DTOs.Charge
{
    public class DetailedChargeDTO
    {
        public int Id { get; set; }
        public int CardId { get; set; }

        public int Amount { get; set; }

        public int AvaibleCredit { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
