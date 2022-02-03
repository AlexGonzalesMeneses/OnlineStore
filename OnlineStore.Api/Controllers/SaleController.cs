using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Services;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;
        private readonly ILoggerManager loggerManager;
        
        public SaleController(ISaleService saleService, ILoggerManager loggerManager)
        {
            this.saleService = saleService;
            this.loggerManager = loggerManager;
        }

        // GET: api/<saleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var sales = saleService.GetAll();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get sales");
            }
        }

        [HttpGet("search")]

        // GET api/<saleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var sale = saleService.GetById(id);
                return sale.Id == Guid.Empty ? (IActionResult)NotFound() : Ok(sale);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get sale");
            }
        }

        // POST api/<saleController>
        [HttpPost]
        public IActionResult Post([FromBody] Sale sale)
        {
            try
            {
                var existingsale = saleService.GetById(sale.Id);

                if (existingsale.Id != Guid.Empty)
                {
                    return BadRequest("sale already exists");
                }

                var newsale = saleService.Add(sale);

                return Ok(newsale);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to add sale");
            }
        }

        // PUT api/<saleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Sale sale)
        {
            try
            {
                var updatedsale = saleService.GetById(id);

                if (updatedsale.Id == Guid.Empty)
                {
                    return NotFound("sale not exists");
                }

                updatedsale.OrderId = sale.OrderId;
                updatedsale.CustomerId = sale.CustomerId;

                return Ok(saleService.Update(updatedsale));
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to update sale");
            }
        }

        // DELETE api/<saleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var sale = saleService.GetById(id);

                if (sale.Id == Guid.Empty)
                {
                    return NotFound("sale not exists");
                }

                saleService.Delete(sale);

                return NoContent();
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to delete sale");
            }
        }
    }
}
