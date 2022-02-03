using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Api.Services;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILoggerManager logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to get products");
            }
        }

        // GET api/<search>/5
        [HttpGet("search")]
        public IActionResult Get([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Name is required");
                }

                var products = productService.Search(p => p.Name.Contains(name));
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet("search")]

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = productService.GetById(id);
                return product.Id == Guid.Empty ? (IActionResult)NotFound() : Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to get product");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                var existingProduct = productService.GetById(product.Id);
                
                if (existingProduct.Id != Guid.Empty)
                {
                    return BadRequest("Product already exists");
                }

                var newProduct =productService.Add(product);

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to add product");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product product)
        {
            try
            {
                var updatedProduct = productService.GetById(id);
                
                if (updatedProduct.Id == Guid.Empty)
                {
                    return NotFound("Product not exists");
                }

                updatedProduct.Name = product.Name;
                updatedProduct.Stock = product.Stock;
                updatedProduct.CategoryId = product.CategoryId;

                return Ok(productService.Update(updatedProduct));
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to update product");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = productService.GetById(id);
                
                if (product.Id == Guid.Empty)
                {
                    return NotFound("Product not exists");
                }

                productService.Delete(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return BadRequest("Failed to delete product");
            }
        }
    }
}
