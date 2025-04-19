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
    public class OrderService : IOrderService
    {
        private readonly GroceryDbContext _groceryDb;
        private readonly IMapper _mapper;

        public OrderService(GroceryDbContext groceryDb,IMapper mapper)
        {
            _groceryDb = groceryDb;
            _mapper = mapper;
        }
        public async Task CreateOrder(OrdersDto orderDto)
        {
            try
            {
                if(orderDto == null)
                {
                    throw new ArgumentNullException( "Parameters can not be null");
                }
                var existingCustomer = await _groceryDb.Customers_tbl.FirstOrDefaultAsync(c => c.Id == orderDto.CustomerId);
                if (existingCustomer == null)
                {
                    throw new Exception($"Customer with ID {orderDto.CustomerId} does not exist.");
                }
                var orderModel = _mapper.Map<Orders>(orderDto);
                orderModel.CreatedDate = DateTime.Now;
                orderModel.ModifiedDate = null;

                orderModel.OrderItems = new List<OrderItems>();
                foreach(var orderItemDto in orderDto.OrderItemsDto)
                {
                    var stock = await _groceryDb.Stocks_tbl.FirstOrDefaultAsync(s => s.ItemId == orderItemDto.ItemId);
                    if (stock != null && stock.Quantity>orderItemDto.Quantity)
                    {
                        var orderItemModel = _mapper.Map<OrderItems>(orderItemDto);
                        orderItemModel.CreatedDate = DateTime.Now;
                        orderItemModel.ModifiedDate = null;
                        orderItemModel.CategoryId = stock.CategoryId;
                        orderItemModel.CostPerQuantity = stock.CostPerQuantity;
                        orderItemModel.TotalCost = stock.CostPerQuantity * orderItemModel.Quantity;
                        orderModel.OrderItems.Add(orderItemModel);
                    }              
                }
                //orderModel.CustomerId = 
                await _groceryDb.Orders_tbl.AddAsync(orderModel);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
