using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationWebAPI.Model.ResponseModel
{
    [Keyless]
    public class CommonResponse
    {
        [Column("outputInfo")]
        public string? outputInfo { get; set; }

        [Column("rsltType")]
        public int? rsltType { get; set; }
    }
}
