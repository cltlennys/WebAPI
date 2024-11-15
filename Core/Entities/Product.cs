using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int  EntityId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = null!; 

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public Entity Entity { get; set; } = null!;


    }
}
