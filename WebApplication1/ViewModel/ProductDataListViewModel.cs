using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ProductDataListViewModel
    {

        public IEnumerable<Contract> Contracts { get; set; }
        public SelectList Days { get; set; }
        public SelectList Months { get; set; }
        public SelectList Years { get; set; }

    }
}