using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12.Models
{
    public class Vegan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int VeganTypeId { get; set; }
        public VeganType VeganTypes { get; set; }
    }
}
