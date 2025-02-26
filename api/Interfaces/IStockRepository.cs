using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stocks>> GetAllAsync(QueryObject query);
        Task<Stocks?> GetbByIdAsync(int id);
        Task<Stocks?> GetBySymbolAsync(string symbol);
        Task<Stocks> CreateAsync(Stocks stockModel);
        Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDTO stockdto);
        Task<Stocks?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}