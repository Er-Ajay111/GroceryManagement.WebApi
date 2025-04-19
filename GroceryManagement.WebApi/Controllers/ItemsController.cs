using GroceryManagement.BL.IServices;
using GroceryManagement.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _item;

        public ItemsController(IItemService item)
        {
            _item = item;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewItem(ItemsDto itemDto)
        {
            try
            {
                await _item.AddItem(itemDto);
                return Ok("New Item created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItemsDetails()
        {
            try
            {
                var data = await _item.GetAllItems();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItemDetailsById(int id)
        {
            try
            {
                var data = await _item.GetItemById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItemDetails(ItemsDto itemDto)
        {
            try
            {
                await _item.UpdateItem(itemDto);
                return Ok($"Item details updated successfully with id : {itemDto.ItemId}");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await _item.DeleteItem(id);
                return Ok($"Item deleted successfully with id : {id}");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
