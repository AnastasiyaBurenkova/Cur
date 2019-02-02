using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ClientVidSListViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
        public string Vids { get; set; }
        public SelectList Clients { get; set; }
        public double? Sums { get; set; }
        public double? Sumk { get; set; }
        public double? Suma { get; set; }

    }
}