using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ContractsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public SelectList ID { get; set; }
        public SelectList Name { get; set; }
      //  public string Name { get; set; }
    }
}