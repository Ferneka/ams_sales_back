using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS_Sales.Context;
using AMS_Sales.Domain;
using AMS_Sales.Domain.Request;
using Microsoft.AspNetCore.Mvc;
using AMS_Sales.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace AMS_Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public CategoryController(ApplicationDataContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(){
            var categories = await _context.Category.Where(c => c.IsActive == true).ToListAsync();
            if(categories == null) return NotFound();
            var response = new List<CategoryDto>();
            foreach(var category in categories){
                    response.Add(
                    new CategoryDto{
                    Id = category.Id,
                    Description =  category.Description,
                    ImageURL = category.ImageURL
                    });
            }
            return Ok(response);
        }
        [HttpPost("{categoryRequest}")]
        public ActionResult Post(CategoryRequest categoryRequest){
            var category = new Category(){
                Description = categoryRequest.Description,
                IsActive = true,
                ImageURL = categoryRequest.ImageURL
            };
            _context.Category.Add(category);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public ActionResult<Category> GetCategoryById(Guid id){
            var category = _context.Category.FirstOrDefault(cat => cat.Id == id);
            if(category == null) return NotFound();
            return Ok(category);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public ActionResult Update(Guid id, CategoryRequest categoryRequest){
            var category =  _context.Category.Find(id);
            if(category == null) return NotFound();
            category.Description = categoryRequest.Description;
            category.ImageURL = categoryRequest.ImageURL;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public ActionResult Delete(Guid id){
            var category = _context.Category.Find(id);
            if(category == null) return NotFound();
            category.IsActive = false;
            _context.SaveChanges();
            return Ok();
        }

    }
}