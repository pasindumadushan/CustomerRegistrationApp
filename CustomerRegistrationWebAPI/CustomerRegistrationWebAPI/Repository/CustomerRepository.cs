using CustomerRegistrationWebAPI.IRepository;
using CustomerRegistrationWebAPI.Model;
using CustomerRegistrationWebAPI.Model.RequestModel;
using CustomerRegistrationWebAPI.Model.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationWebAPI.Repository
{
    public class CustomerRepository : CustomerIRepository
    {
        private readonly DBContext _context;


        public CustomerRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerInfoResponse>> GetCustomers()
        {
            try
            {
                var result = await _context.Set<CustomerInfoResponse>().FromSqlRaw("GetCustomerInfo @P0", "ALL").ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CustomerInfoResponse>> GetCustomerByName(string customerName)
        {
            var result = await _context.Set<CustomerInfoResponse>().FromSqlRaw("GetCustomerInfo @P0, @P1, @P2", "FINDBYNAME", null,customerName).ToListAsync();

            return result;
        }

        public async Task<CustomerInfoResponse> GetCustomer(int id)
        {

            var result = (await _context.Set<CustomerInfoResponse>().FromSqlRaw("GetCustomerInfo @P0, @P1", "FIND", id).ToListAsync()).FirstOrDefault();

            return result;
        }


        public async Task<CommonResponse> PostCustomer(CustomerInfoRequest customer)
        {

            var result = (await _context.Set<CommonResponse>().FromSqlRaw("SetCustomerInfo @P0, @P1, @P2, @P3, @P4, @P5", "INSERT", customer.CustomerId, customer.CustomerName, customer.CustomerPnum, customer.CustomerAddress, customer.CustomerEmail).ToListAsync()).FirstOrDefault();

            return result;
        }

        public async Task<CommonResponse> PutCustomer(CustomerInfoRequest customer)
        {

            var result = (await _context.Set<CommonResponse>().FromSqlRaw("SetCustomerInfo @P0, @P1, @P2, @P3, @P4, @P5", "UPDATE", customer.CustomerId, customer.CustomerName, customer.CustomerPnum, customer.CustomerAddress, customer.CustomerEmail).ToListAsync()).FirstOrDefault();

            return result;
        }

        public async Task<CommonResponse> DeleteCustomer(int id)
        {
            var result = (await _context.Set<CommonResponse>().FromSqlRaw("SetCustomerInfo @P0, @P1, @P2, @P3, @P4, @P5", "DELETE", id, null, null, null, null).ToListAsync()).FirstOrDefault();

            return result;
        }
    }
}
