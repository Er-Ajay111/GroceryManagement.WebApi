using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GroceryManagement.BL.IServices;
using GroceryManagement.DB.Data;
using GroceryManagement.DB.Models;
using GroceryManagement.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.BL.Imlementation
{
    public class CustomerService : ICustomerService
    {
        private readonly GroceryDbContext _groceryDb;
        private readonly IMapper _mapper;

        public CustomerService(GroceryDbContext groceryDb,IMapper mapper)
        {
            _groceryDb = groceryDb;
            _mapper = mapper;
        }
        public async Task AddCustomer(CustomersDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var data= await _groceryDb.Customers_tbl.FirstOrDefaultAsync(x => x.EmailId == customerDto.CustomerEmailId);
                if (data != null)
                {
                    throw new Exception($"Customer already exists with EmailId : {customerDto.CustomerEmailId}");
                }
                var customer = _mapper.Map<Customers>(customerDto);
                customer.CreatedDate = DateTime.Now;
                customer.ModifiedDate =null;
                customer.CreatedDate = DateTime.Now;
                await _groceryDb.Customers_tbl.AddAsync(customer);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                if(id <= 0)
                {
                    throw new ArgumentNullException("id must be greater than zero");
                }
                var data = await _groceryDb.Customers_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    throw new Exception($"Customer not found with id : {id}");
                }
                _groceryDb.Customers_tbl.Remove(data);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CustomersDto>> GetAllCustomers()
        {
            try
            {
                var allCustomers = await _groceryDb.Customers_tbl.ToListAsync();
                if (allCustomers.Count<=0)
                {
                    throw new Exception("No Customers found");
                }
                var customers = _mapper.Map<List<CustomersDto>>(allCustomers);
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomersDto> GetCustomerById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException("id must be greater than zero");
                }
                var customer =await _groceryDb.Customers_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (customer == null)
                {
                    throw new Exception($"Customer not found with id : {id}");
                }
                var customerDto = _mapper.Map<CustomersDto>(customer);
                return customerDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCustomerDetails(CustomersDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var customer = await _groceryDb.Customers_tbl.FirstOrDefaultAsync(x => x.Id == customerDto.CustomerId);
                if (customer == null)
                {
                    throw new Exception($"Customer not found with id : {customerDto.CustomerId}");
                }
                customer.Name = customerDto.CustomerName;
                customer.EmailId = customerDto.CustomerEmailId;
                customer.Address = customerDto.CustomerAddress;
                customer.PhoneNo = customerDto.CustomerPhoneNo;
                customer.CreatedDate = null;
                customer.ModifiedDate = DateTime.Now;
                _groceryDb.Customers_tbl.Update(customer);
                _groceryDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
