using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Manager
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public Manager()
        {
            Contracts = new List<Contract>();
        }
    }
}