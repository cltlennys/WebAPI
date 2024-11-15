using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Entity
{
    public class CreateEntityDTO
    {

        public string Name {  get; set; } = string.Empty;

        public int Id { get; set; }

        public int CustomerId { get; set; }

    }
}
