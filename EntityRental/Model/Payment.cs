using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; } = 0.0m;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
