using CustomerRegistrationWebAPI.Model.ResponseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationWebAPI.Model
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<CommonResponse> CustomerInfo { get; set; }
        public DbSet<CustomerInfoResponse> CustomerInfoResponse { get; set; }
    }
}
