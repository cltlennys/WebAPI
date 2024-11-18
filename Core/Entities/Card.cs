using Core.DTOs;

namespace Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Type { get; set;  } = string.Empty;

        public string Number { get; set; } = string.Empty ;

        public DateTime ExpirationDate { get; set; }

        public int CreditLimit { get; set; } 

        public int AvailableCredit {  get; set; }

        public decimal InteresRate { get; set; }

        public string Status { get; set; } = string.Empty;

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public List<Charge> Charges { get; set; } = null!;

        public List<Payment> Payments { get; set; } = null!;
    }
}
