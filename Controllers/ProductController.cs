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
using AMS_Sales.Domain.DTO;

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
                CreatedDate = productRequest.CreatedDate,
                IdCategory = productRequest.IdCategory
            };
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(){
            var listProduct = await  _context.Product.Where(p => p.IsActive == true).Include(p => p.Category).ToListAsync();
            if(listProduct == null) return NotFound();
            var response = new List<ProductDto>();
            foreach(var product in listProduct){
                    response.Add(
                    new ProductDto{
                        Id = product.Id,
                        Description = product.Description,
                        Stock = product.Stock,
                        Price = product.Price,
                        ImageURL = product.ImageURL,
                        CategoryDto =  new CategoryDto{
                            Id = product.Category.Id,
                            Description = product.Category.Description,
                            ImageURL = product.Category.ImageURL 
                        }  
                    }
                );
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public ActionResult<Product> GetProductById(Guid id){
            var product = _context.Product.FirstOrDefault(prod => prod.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPut]
        [Route("id:guid")]
        public ActionResult Update(Guid id, ProductRequest productRequest){
            var product = _context.Product.Find(id);
            if (product == null) return NotFound(); 
            product.Description = productRequest.Description;
            product.Stock = productRequest.Stock;
            product.Price = productRequest.Price;
            product.ImageURL = productRequest.ImageURL;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("id:guid")]
        public ActionResult Delete(Guid id){
            var product = _context.Product.Find(id);
            if(product == null) return NotFound();
            product.IsActive = false;
            _context.SaveChanges();
            return Ok();
        }

        
    }
}