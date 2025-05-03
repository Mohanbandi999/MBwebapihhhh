using System;
using System.Collections.Generic;

namespace MBwebapi.Models
{
    public partial class Customer
    {
        public int CustId { get; set; }
        public string? CustName { get; set; }
        public long? CustMobileNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? PinCode { get; set; }
        public string? Gender { get; set; }
    }
}
