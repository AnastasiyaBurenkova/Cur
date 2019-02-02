using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public SelectList Vids { get; set; }
        public SelectList Date { get; set; }
        public SelectList EndDate { get; set; }
        public double? Procent { get; set; }
    }
}