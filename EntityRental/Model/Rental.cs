using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Rental
    {
        public int RentalId { get; set; }
        public int RentalDate { get; set; } // Assuming this is a timestamp or similar
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int ReturnDate { get; set; } // Assuming this is a timestamp or similar
        public int StaffId { get; set; }
        public string? LastUpdate { get; set; } // Assuming this is a timestamp or similar
    }
}
