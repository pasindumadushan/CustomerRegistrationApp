using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerRegistrationWebAPI.Model.RequestModel
{
    public class CustomerInfoRequest
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPnum { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
    }
}
