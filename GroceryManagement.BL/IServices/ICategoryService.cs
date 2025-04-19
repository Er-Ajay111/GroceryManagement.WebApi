using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(int id);
        Task AddCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}
