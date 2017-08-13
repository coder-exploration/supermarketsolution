using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.MVC.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}