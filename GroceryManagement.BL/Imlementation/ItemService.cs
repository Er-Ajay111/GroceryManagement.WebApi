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
    public class ItemService : IItemService
    {
        private readonly GroceryDbContext _groceryDb;
        private readonly IMapper _mapper;

        public ItemService(GroceryDbContext groceryDb, IMapper mapper)
        {
            _groceryDb = groceryDb;
            _mapper = mapper;
        }
        public async Task AddItem(ItemsDto itemDto)
        {
            try
            {
                if (itemDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var category = await _groceryDb.Category_tbl.FirstOrDefaultAsync(x => x.Id == itemDto.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }
                var item = await _groceryDb.Items_tbl.FirstOrDefaultAsync(x => x.Name == itemDto.ItemName);
                if (item != null)
                {
                    throw new Exception("Item already exists");
                }
                var itemsModel = _mapper.Map<Items>(itemDto);
                itemsModel.ModifiedDate = null;
                itemsModel.CreatedDate = DateTime.Now;
                await _groceryDb.Items_tbl.AddAsync(itemsModel);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteItem(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException("id must be greater than zero");
                }
                var item = await _groceryDb.Items_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    throw new Exception("There is no item found to delete");
                }
                _groceryDb.Items_tbl.Remove(item);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ItemsDto>> GetAllItems()
        {
            try
            {
                var allItems = await _groceryDb.Items_tbl.ToListAsync();
                if (allItems.Count <= 0)
                {
                    throw new Exception("There is no item found");
                }
                var itemsDto = _mapper.Map<List<ItemsDto>>(allItems);
                return itemsDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ItemsDto> GetItemById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException("id must be greater than zero");
                }
                var item = await _groceryDb.Items_tbl.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    throw new Exception($"Item not found with id : {id}");
                }
                var itemDto = _mapper.Map<ItemsDto>(item);
                return itemDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateItem(ItemsDto itemDto)
        {
            try
            {
                if(itemDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var item = await _groceryDb.Items_tbl.FirstOrDefaultAsync(x => x.Id == itemDto.ItemId);
                if (item == null)
                {
                    throw new Exception($"There is no item to update with id : {itemDto.ItemId}");
                }
                _mapper.Map(itemDto, item);
                item.CreatedDate = null;
                item.ModifiedDate = DateTime.Now;
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
