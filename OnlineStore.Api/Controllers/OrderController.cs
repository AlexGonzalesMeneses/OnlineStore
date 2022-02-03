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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILoggerManager loggerManager;

        public OrderController(IOrderService orderService, ILoggerManager loggerManager)
        {
            this.orderService = orderService;
            this.loggerManager = loggerManager;
        }

        // GET: api/<orderController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orders = orderService.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get orders");
            }
        }

        // GET api/<orderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var order = orderService.GetById(id);
                return order.Id == Guid.Empty ? NotFound() : Ok(order);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get order");
            }
        }

        // POST api/<orderController>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                var existingorder = orderService.GetById(order.Id);

                if (existingorder.Id != Guid.Empty)
                {
                    return BadRequest("order already exists");
                }

                var neworder = orderService.Add(order);

                return Ok(neworder);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to add order");
            }
        }

        // PUT api/<orderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Order order)
        {
            try
            {
                var updatedorder = orderService.GetById(id);

                if (updatedorder.Id == Guid.Empty)
                {
                    return NotFound("order not exists");
                }

                updatedorder.ItemId = order.ItemId;
                updatedorder.Total = order.Total;

                return Ok(orderService.Update(updatedorder));
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to update order");
            }
        }

        // DELETE api/<orderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var order = orderService.GetById(id);

                if (order.Id == Guid.Empty)
                {
                    return NotFound("order not exists");
                }

                orderService.Delete(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to delete order");
            }
        }
    }
}
