using CustomerRegistrationWebAPI.IRepository;
using CustomerRegistrationWebAPI.Model.RequestModel;
using CustomerRegistrationWebAPI.Model.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private readonly CustomerIRepository _CustomerIRepository;

        public CustomerRegistrationController(CustomerIRepository CustomerIRepository)
        {
            _CustomerIRepository = CustomerIRepository;
        }

        [Route("GetCustomers")]
        [HttpGet]
        public async Task<ActionResult<List<CustomerInfoResponse>>> GetCustomers()
        {

            var result = await _CustomerIRepository.GetCustomers();
            return Ok(result);

        }

        [Route("GetCustomers/{id}")]
        [HttpGet]
        public async Task<ActionResult<List<CustomerInfoResponse>>> GetCustomer(int id)
        {

            var result = await _CustomerIRepository.GetCustomer(id);
            return Ok(result);

        }

        [Route("GetCustomersByName/{customerName}")]
        [HttpGet]
        public async Task<ActionResult<List<CustomerInfoResponse>>> GetCustomerByName(string customerName)
        {

            var result = await _CustomerIRepository.GetCustomerByName(customerName);
            return Ok(result);

        }

        [Route("PostCustomer")]
        [HttpPost]
        public async Task<ActionResult<List<CustomerInfoResponse>>> PostCustomer(CustomerInfoRequest Customer)
        {

            var result = await _CustomerIRepository.PostCustomer(Customer);
            return Ok(result);

        }

        [Route("PutCustomer")]
        [HttpPost]
        public async Task<ActionResult<List<CustomerInfoResponse>>> PutCustomer(CustomerInfoRequest Customer)
        {

            var result = await _CustomerIRepository.PutCustomer(Customer);
            return Ok(result);

        }


        [Route("DeleteCustomer/{id}")]
        [HttpPost]
        public async Task<ActionResult<List<CustomerInfoResponse>>> DeleteCustomer(int id)
        {

            var result = await _CustomerIRepository.DeleteCustomer(id);
            return Ok(result);

        }
    }
}
