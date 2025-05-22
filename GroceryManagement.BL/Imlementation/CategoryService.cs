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
    public class CategoryService : ICategoryService
    {
        private readonly GroceryDbContext _groceryDb;
        private readonly IMapper _mapper;

        public CategoryService(GroceryDbContext groceryDb, IMapper mapper)
        {
            _groceryDb = groceryDb;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var data = await _groceryDb.Category_tbl.FirstOrDefaultAsync(x => x.Name == categoryDto.CategoryName);
                if (data != null)
                {
                    throw new Exception("Category already exists");
                }
                var category = _mapper.Map<Category>(categoryDto);
                category.ModifiedDate = null;
                category.CreatedDate = DateTime.Now;
                await _groceryDb.Category_tbl.AddAsync(category);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task DeleteCategory(int id)
        {
            try
            {
                var data = await _groceryDb.Category_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (data == null)
                {
                    throw new Exception($"Category not found with id : {id}");
                }
                _groceryDb.Category_tbl.Remove(data);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            try
            {
                var allCategories = await _groceryDb.Category_tbl.ToListAsync();
                if (allCategories.Count <= 0)
                {
                    throw new Exception("No categories found");
                }
                var categoryDto = _mapper.Map<List<CategoryDto>>(allCategories);
                return categoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                var category = await _groceryDb.Category_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    throw new Exception($"Category not found with id : {id}");
                }
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var data =await _groceryDb.Category_tbl.FirstOrDefaultAsync(x => x.Id == categoryDto.CategoryId);
                if (data == null)
                {
                    throw new Exception($"Category not found with Id : {categoryDto.CategoryId}");
                }
                _mapper.Map(categoryDto, data);
                data.CreatedDate = null;
                data.ModifiedDate = DateTime.Now;
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
