using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Measurement { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoBase64 { get; set; }
    }
}