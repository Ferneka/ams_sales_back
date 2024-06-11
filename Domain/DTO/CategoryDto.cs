using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS_Sales.Domain.DTO
{
    public class CategoryDto
    {
        public Guid Id { get; set; } 
        public string Description {get; set;}
        public string ImageURL {get; set;}
    }
}