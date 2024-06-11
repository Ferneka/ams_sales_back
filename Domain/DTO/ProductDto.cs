using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS_Sales.Domain.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; } 
        public string Description {get; set;}
        public double Stock {get; set;}
        public double Price {get; set;}
        public string ImageURL {get; set;}
        public DateTime CreatedDate { get; set; }
        public CategoryDto CategoryDto {get; set;}
    }
}