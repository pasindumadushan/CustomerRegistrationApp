using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerRegistrationWebAPI.Model.ResponseModel
{
    [Keyless]
    public partial class CustomerInfoResponse
    {
        [Column("CustomerId")]
        public int? CustomerId { get; set; }

        [Column("CustomerName")]
        public string CustomerName { get; set; }

        [Column("CustomerPNum")]
        public string CustomerPNum { get; set; }

        [Column("CustomerAddress")]
        public string CustomerAddress { get; set; }

        [Column("CustomerEmail")]
        public string CustomerEmail { get; set; }
    }
}
