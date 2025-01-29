using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    public class StockController : ControllerBase

    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockrepo;
        public StockController(ApplicationDbContext context, IStockRepository stockRepo)
        {
            _context = context;
            _stockrepo = stockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var stocks = await _stockrepo.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockrepo.GetbByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            var stockModel = stockDTO.ToStockFromCreateDto();
            await _stockrepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO updateDto)
        {
            var stockModel = await _stockrepo.UpdateAsync(id, updateDto);
            if (stockModel == null) { return NotFound(); }


            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockrepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}