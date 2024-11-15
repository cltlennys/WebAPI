using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Customer;

namespace Core.DTOs.Card
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int CreditLimit { get; set; }

        public string Type { get; set; } = string.Empty;

        public int AvailableCredit { get; set; }

        public decimal InteresRate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Status { get; set; } = string.Empty;
        public CustomerDTO Customer { get; set; } = null!;

        public int CustomerId { get; set; }




    }
}
