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
    public class StockService : IStockService
    {
        private readonly GroceryDbContext _groceryDb;
        private readonly IMapper _mapper;

        public StockService(GroceryDbContext groceryDb,IMapper mapper)
        {
            _groceryDb = groceryDb;
            _mapper = mapper;
        }
        private string GenerateInvoiceNo()
        {
            var datePart = DateTime.Now.ToString("yyyyMMdd");
            var randomPart = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            return $"INV-{datePart}-{randomPart}";
        }
        public async Task AddStock(StocksDto stockDto)
        {
            try
            {
                if (stockDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var stock = await _groceryDb.Stocks_tbl.FirstOrDefaultAsync(c => c.Id == stockDto.ItemId);
                if (stock?.Quantity >= 100)
                {
                    throw new ArgumentException($"Item with ID {stockDto.ItemId} already exists in sufficient quantity");
                }
                var existingCategory = await _groceryDb.Items_tbl.FirstOrDefaultAsync(c => c.Id == stockDto.ItemId);
                if (existingCategory == null)
                {
                    throw new ArgumentException($"Item with ID {stockDto.ItemId} does not exist.");
                }
                var stockModel = _mapper.Map<Stocks>(stockDto);
                stockModel.InvoiceNo = GenerateInvoiceNo();
                stockModel.CategoryId = existingCategory?.CategoryId;
                stockModel.CreatedDate = DateTime.Now;
                stockModel.ModifiedDate = null;
                stockModel.InvoiceDate = DateTime.Now;
                stockModel.TotalCost = stockModel.Quantity * stockModel.CostPerQuantity;
                await _groceryDb.Stocks_tbl.AddAsync(stockModel);
                await _groceryDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StocksDto>> GetAllStocks()
        {
            try
            {
               var allStocks =await _groceryDb.Stocks_tbl.ToListAsync();
                if (allStocks.Count<=0)
                {
                    throw new Exception("No stocks found");
                }
                var stockDto = _mapper.Map<List<StocksDto>>(allStocks);
                return stockDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
