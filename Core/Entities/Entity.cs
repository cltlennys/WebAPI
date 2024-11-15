using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Entity
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string EntityName {  get; set; } = string.Empty;

        public List<Product> Products { get; set; } = null!;

        public Customer Customer { get; set; } = null!;

    }
}
