using GroceryManagement.BL.IServices;
using GroceryManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _order;

        public OrdersController(IOrderService order)
        {
            _order = order;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder(OrdersDto orderDto)
        {
            try
            {
                await _order.CreateOrder(orderDto);
                return Ok("New Order created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
