namespace Core.DTOs.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        public int Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public int AvaibleCredit { get; set; }

        public DateTime Date { get; set; }

        public decimal Debt { get; set; }





    }
}
