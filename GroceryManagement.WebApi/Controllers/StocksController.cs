using GroceryManagement.BL.IServices;
using GroceryManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stock;

        public StocksController(IStockService stock)
        {
            _stock = stock;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStock(StocksDto stockDto)
        {
            try
            {
                await _stock.AddStock(stockDto);
                return Ok("New Stock created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStocksDetails()
        {
            try
            {
                var data = await _stock.GetAllStocks();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
