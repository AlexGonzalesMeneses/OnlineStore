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
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        private readonly ILoggerManager loggerManager;

        public ItemController(IItemService itemService, ILoggerManager loggerManager)
        {
            this.itemService = itemService;
            this.loggerManager = loggerManager;
        }

        // GET: api/<itemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = itemService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get items");
            }
        }

        // GET api/<itemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var item = itemService.GetById(id);
                return item.Id == Guid.Empty ? NotFound() : Ok(item);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get item");
            }
        }

        // POST api/<itemController>
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            try
            {
                var existingitem = itemService.GetById(item.Id);
                
                if (existingitem.Id != Guid.Empty)
                {
                    return BadRequest("item already exists");
                }

                var newitem =itemService.Add(item);

                return Ok(newitem);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to add item");
            }
        }

        // PUT api/<itemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Item item)
        {
            try
            {
                var updateditem = itemService.GetById(id);
                
                if (updateditem.Id == Guid.Empty)
                {
                    return NotFound("item not exists");
                }

                updateditem.UnitPrice = item.UnitPrice;
                updateditem.Quantity = item.Quantity;
                updateditem.ProductId = item.ProductId;

                return Ok(itemService.Update(updateditem));
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to update item");
            }
        }

        // DELETE api/<itemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var item = itemService.GetById(id);
                
                if (item.Id == Guid.Empty)
                {
                    return NotFound("item not exists");
                }

                itemService.Delete(item);

                return NoContent();
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to delete item");
            }
        }
    }
}
