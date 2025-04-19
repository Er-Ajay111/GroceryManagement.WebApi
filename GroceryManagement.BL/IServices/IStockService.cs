using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.IServices
{
    public interface IStockService
    {
        Task AddStock(StocksDto stockDto);
        //Task<List<StocksDto>> GetAllStocks();
        //Task<StocksDto> GetStockById(int id);
        //Task UpdateStock(StocksDto stockDto);
        //Task DeleteStock(int id);
    }
}
