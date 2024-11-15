

namespace Core.DTOs.Charge
{
    public class ChargeDTO
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int AvaibleCredit { get; set; }

        public string Description { get; set; } = string.Empty;


        public DateTime Date { get; set; }
        public decimal Debt { get; set; }
    }
}
