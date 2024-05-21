using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS_Sales.Context;
using AMS_Sales.Domain;
using AMS_Sales.Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMS_Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public ProductController(ApplicationDataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult Post(ProductRequest productRequest){
            var product = new Product(){
                Description = productRequest.Description,
                Stock = productRequest.Stock,
                Price = productRequest.Price,
                ImageURL = productRequest.ImageURL,
                IsActive = true,
                IdCategory = productRequest.IdCategory
            };
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll(){
            var listProduct = _context.Product.Include(p => p.Category).ToList();
            var mapearProduct = listProduct.Select(p => new Product{
                Id = p.Id,
                Description = p.Description,
                Stock = p.Stock,
                Price = p.Price,
                ImageURL = p.ImageURL,
                IdCategory = p.IdCategory,
                Category =  new Category{
                    Id = p.Category.Id,
                     Description = p.Category.Description
                 }
            }).ToList();
            return Ok(mapearProduct);
        }
        [HttpGet("{id:guid}")]
        public ActionResult<Product> GetProductById(Guid id){
            var product = _context.Product.FirstOrDefault(prod => prod.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        
    }
}