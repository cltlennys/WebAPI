

namespace Core.DTOs.Payment
{
    public class CreatePaymentDTO
    {

        public int Amount { get; set; }

        public int CardId { get; set; }


        public string PaymentMethod { get; set; } = string.Empty;

        public DateTime Date {  get; set; }
    }
}
