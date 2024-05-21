using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS_Sales.Context;
using AMS_Sales.Domain;
using AMS_Sales.Domain.Request;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Category>> GetAll(){
            return _context.Category.ToList();
        }
        [HttpPost]
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

    }
}