﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityRental.Model
{
    internal class Staff
    {
        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int AddressId { get; set; }
        public string? Email { get; set; }  
        public int StoreId { get; set; }
        public bool Active { get; set; } = true;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? LastUpdate { get; set; }
    }
}
