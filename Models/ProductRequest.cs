using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApp.Models
{
    public class ProductRequest
    {
        public string ProductId { get; set; } 
        public string ProductSerialnumber { get; set; } 
        public string AdminId { get; set; }
        public string CategoryId { get; set; } 
    }
    public class ProductsEdit : ProductRequest
    {
        public string ProductId { get; set; } 
    }

    public class ProductSerialsRequest
    {
        public string ProductSerialnumber { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }

    public class ProductSerialEdit : ProductSerialsRequest
    {
        public string ProductSerialnumber { get; set; }
    }
    public class JoinTable
    {
        public string ProductId { get; set; }
        public string ProductSerialnumber { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string CategoryName { get; set; }
    }
}