

namespace Core.DTOs.Transaction
{
    public class TransactionDTO
    {

        public int Id { get; set; }

        public string Type {  get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty ;

        public DateTime TransactionDate { get; set; }

    }
}
