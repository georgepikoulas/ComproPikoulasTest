using AutoMapper;
using ComproPikoulasTest.API.Models;
using ComproPikoulasTest.Business.Services;
using ComproPikoulasTest.Core;
using ComproPikoulasTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ComproPikoulasTest.API.Controllers
{
    [Route("api/customers/")]

    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly ComproPikoulasTestDbContext dbContext;
        const int maxCustomerPageSize = 20;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, ComproPikoulasTestDbContext dbContext)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ActionResult<CustomerDTONoOrders>> CreateCustomer(
       Customer customerdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound(ModelState.ValidationState.ToString() + "Error exists");
                }
                var validEmail = new Validator();
                if (customerdto.Email != null)
                {
                    validEmail.IsEmailValid(customerdto.Email);
                }
                var customer = mapper.Map<Customer>(customerdto);
                if (await customerRepository.CustomerExistsAsync(customer) == null)
                {
                    return NotFound("Customer exists");
                }
                else
                {

                    dbContext.Customers.Add(customer);
                    //await dbContext.Customers.AddCustomerAsync(
                    //   Orders);
                    if (customer.Orders != null && customer.Orders.FirstOrDefault(p => p.CustomerId > 0) != null)
                    {
                        dbContext.Orders.AddRange(customer.Orders);
                    }

                    await dbContext.SaveChangesAsync();

                    // var customerRet = mapper.Map<CustomerDTO>(customer);




                    return Ok(customer);

                }
            }
            catch (Exception ex )
            {

                return NotFound(ex.Message);
            }
            
        }

        [HttpDelete("{customerid}")]
        public async Task<ActionResult> DeleteCustomer(int customerid)
        {
            var dbCust = await customerRepository.CustomerGetById(customerid);
            if (dbCust == null)
            {
                return NotFound();
            }
            else
            {
                var customer = mapper.Map<Customer>(dbCust);

                dbContext.Customers.Remove(customer);
                await customerRepository.SaveChangesAsync();

                return Ok(customer);
            }
        }

        [HttpPut("{customerid}")]
        public async Task<ActionResult> UpdateCustomer(int customerid,
           Customer customerdto)
         {
            var dbCust = await dbContext.Customers.FindAsync(customerid);
            if (dbCust == null)
            {
                return NotFound();
            }
            else
            {
                var customer = mapper.Map<Customer>(dbCust);
                dbCust = customerdto;
                dbContext.Customers.Update(dbCust);
                await customerRepository.SaveChangesAsync();

                return Ok(customer);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers(
            string? name, string? lastName , string? email , string? phone , int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCustomerPageSize)
            {
                pageSize = maxCustomerPageSize;
            }

            var (customers, paginationMetadata) = await customerRepository
                .GetCustomersPagedAsync( name,  lastName ,  email ,  phone , pageNumber, pageSize);

            Response.Headers.Append("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(mapper.Map<IEnumerable<CustomerDTO>>(customers));
        }


    }
}
