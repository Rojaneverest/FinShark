using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDTO ToStockDto(this Stocks stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stocks ToStockFromCreateDto(this CreateStockRequestDTO stockRequestDTO)
        {
            return new Stocks
            {
                Symbol = stockRequestDTO.Symbol,
                CompanyName = stockRequestDTO.CompanyName,
                Purchase = stockRequestDTO.Purchase,
                LastDiv = stockRequestDTO.LastDiv,
                Industry = stockRequestDTO.Industry,
                MarketCap = stockRequestDTO.MarketCap
            };
        }
        public static Stocks ToStockFromFMP(this FMPStock fmpStock)
        {
            return new Stocks
            {
                Symbol = fmpStock.symbol,
                CompanyName = fmpStock.companyName,
                Purchase = (decimal)fmpStock.price,
                LastDiv = (decimal)fmpStock.lastDiv,
                Industry = fmpStock.industry,
                MarketCap = fmpStock.mktCap
            };
        }
    }
}