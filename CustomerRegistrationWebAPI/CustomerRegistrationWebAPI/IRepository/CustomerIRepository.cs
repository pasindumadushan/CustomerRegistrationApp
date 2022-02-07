using CustomerRegistrationWebAPI.Model;
using CustomerRegistrationWebAPI.Model.RequestModel;
using CustomerRegistrationWebAPI.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationWebAPI.IRepository
{
    public interface CustomerIRepository
    {
        Task<IEnumerable<CustomerInfoResponse>> GetCustomers();
        Task<CustomerInfoResponse> GetCustomer(int id);
        Task<IEnumerable<CustomerInfoResponse>> GetCustomerByName(string customerName);
        Task<CommonResponse> PostCustomer(CustomerInfoRequest customer);
        Task<CommonResponse> PutCustomer(CustomerInfoRequest customer);
        Task<CommonResponse> DeleteCustomer(int id);
    }
}
