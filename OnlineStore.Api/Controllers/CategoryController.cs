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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ILoggerManager loggerManager;

        public CategoryController(ICategoryService categoryService, ILoggerManager loggerManager)
        {
            this.categoryService = categoryService;
            this.loggerManager = loggerManager;
        }

        // GET: api/<categoryController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categorys = categoryService.GetAll();
                return Ok(categorys);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get categorys");
            }
        }

        [HttpGet("search")]

        // GET api/<categoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var category = categoryService.GetById(id);
                return category.Id == Guid.Empty ? (IActionResult)NotFound() : Ok(category);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to get category");
            }
        }

        // POST api/<categoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                var existingcategory = categoryService.GetById(category.Id);

                if (existingcategory.Id != Guid.Empty)
                {
                    return BadRequest("category already exists");
                }

                var newcategory = categoryService.Add(category);

                return Ok(newcategory);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to add category");
            }
        }

        // PUT api/<categoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            try
            {
                var updatedcategory = categoryService.GetById(id);

                if (updatedcategory.Id == Guid.Empty)
                {
                    return NotFound("category not exists");
                }

                updatedcategory.Name = category.Name;
                
                return Ok(categoryService.Update(updatedcategory));
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to update category");
            }
        }

        // DELETE api/<categoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var category = categoryService.GetById(id);

                if (category.Id == Guid.Empty)
                {
                    return NotFound("category not exists");
                }

                categoryService.Delete(category);

                return NoContent();
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest("Failed to delete category");
            }
        }
    }
}
