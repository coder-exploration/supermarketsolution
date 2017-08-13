using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.WebAPI.Models
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}