using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string? LastUpdate { get; set; }
    }
}
