using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS_Sales.Domain.DTO;

namespace AMS_Sales.Domain
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description {get; set;}
        public double Stock {get; set;}
        public double Price {get; set;}
        public string ImageURL {get; set;}
        public bool IsActive {get; set;}
        public DateTime CreatedDate {get; set;}
        public Guid IdCategory {get; set;}
        public Category Category {get; set;}
       // public virtual Category Category {get; set;}	
    }
}