using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ClientVidListViewModel
    {
        public IEnumerable<Contract> Clients { get; set; }
        public SelectList Vids { get; set; }
        public SelectList Months { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }
      //  public SelectList Vids { get; set; }
     //   public SelectList Clients { get; set; }

    }
}