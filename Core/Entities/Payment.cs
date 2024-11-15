

namespace Core.Entities
{
    public class Payment
    {

        public int Id { get; set; }

        public int CardId { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public int Amount { get; set; } 

        public DateTime Date {  get; set; }

        public int AvaibleCredit { get; set; }

        public Card Card { get; set; } = null!;

    }
}
