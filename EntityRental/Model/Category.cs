using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public string? LastUpdate { get; set; }
    }
}
