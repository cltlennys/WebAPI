using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Charge
{
    public class CreateChargeDTO
    {
        public int Amount { get; set; }

        public int CardId { get; set; }
        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }


    }
}
