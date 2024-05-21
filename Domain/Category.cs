using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS_Sales.Domain
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description {get; set;}
        public bool IsActive {get; set;}
        public string ImageURL {get; set;}
        public ICollection<Product> Product {get; set;}
     
    } 
}