using GroceryManagement.BL.IServices;
using GroceryManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customer;

        public CustomersController(ICustomerService customer)
        {
            _customer = customer;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomersDto customerDto)
        {
            try
            {
                await _customer.AddCustomer(customerDto);
                return Ok("New Customer created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customer.DeleteCustomer(id);
                return Ok($"Customer deleted successfully with id : {id}");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersDetails()
        {
            try
            {
                var data = await _customer.GetAllCustomers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerDetailsById(int id)
        {
            try
            {
                var data = await _customer.GetCustomerById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerDetails(CustomersDto customerDto)
        {
            try
            {
                await _customer.UpdateCustomerDetails(customerDto);
                return Ok($"Customer details updated successfully with id : {customerDto.CustomerId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
