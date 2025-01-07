using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stocks> CreateAsync(Stocks stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stocks?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stocks>> GetAllAsync()
        {
            return await _context.Stock.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stocks?> GetbByIdAsync(int id)
        {
            return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stock.AnyAsync(s => s.Id == id);
        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDTO stockdto)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stockdto.Symbol;
            existingStock.Purchase = stockdto.Purchase;
            existingStock.MarketCap = stockdto.MarketCap;
            existingStock.LastDiv = stockdto.LastDiv;
            existingStock.CompanyName = stockdto.CompanyName;
            existingStock.Industry = stockdto.Industry;

            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
