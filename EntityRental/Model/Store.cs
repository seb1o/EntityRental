using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Store
    {

        public int StoreId { get; set; }
        public int ManagerStaffId { get; set; }
        public int AddressId { get; set; }
        public string? LastUpdate { get; set; }
    }
}