using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.IServices
{
    public interface IItemService
    {
        Task<List<ItemsDto>> GetAllItems();
        Task<ItemsDto> GetItemById(int id);
        Task AddItem(ItemsDto itemDto);
        Task UpdateItem(ItemsDto itemDto);
        Task DeleteItem(int id);
    }
}
