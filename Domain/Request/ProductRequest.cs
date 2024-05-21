using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS_Sales.Domain.Request
{
    public class ProductRequest
    {
        public string Description {get; set;}
        public double Stock {get; set;}
        public double Price {get; set;}
        public string ImageURL {get; set;}
        public Guid IdCategory {get; set;}
    }
}