using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.IServices
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomersDto customerDto);
        Task DeleteCustomer(int id);
        Task<List<CustomersDto>> GetAllCustomers();
        Task<CustomersDto> GetCustomerById(int id);
        Task UpdateCustomerDetails(CustomersDto customerDto);
    }
}
