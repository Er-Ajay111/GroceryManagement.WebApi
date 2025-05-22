using GroceryManagement.BL.IServices;
using GroceryManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [Authorize(Roles ="Admin,Vendor")]
        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryDto categoryDto)
         {
            try
            {
                await _service.AddCategory(categoryDto);
                return Ok("New Category added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesDetails()
        {
            try
            {
                var data = await _service.GetAllCategories();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryDetailsById(int id)
        {
            try
            {
                var data = await _service.GetCategoryById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryDetails(CategoryDto categoryDto)
        {
            try
            {
                await _service.UpdateCategory(categoryDto);
                return Ok($"Category details updated successfully with id : {categoryDto.CategoryId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _service.DeleteCategory(id);
                return Ok($"Category deleted successfully with Id : {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
