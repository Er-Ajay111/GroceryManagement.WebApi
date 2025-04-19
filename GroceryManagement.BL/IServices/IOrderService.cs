using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.IServices
{
    public interface IOrderService
    {
        Task CreateOrder(OrdersDto orderDto);
    }
}
