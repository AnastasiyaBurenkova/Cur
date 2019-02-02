using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vid { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDate { get; set; }
        public double? Cost { get; set; }
        public int Count { get; set; }
        public string Nomer { get; set; }

       // public ICollection<Product> Vids { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public Product()
        {
           // Vids = new List<Product>();
            Contracts = new List<Contract>();
        }
    }
}