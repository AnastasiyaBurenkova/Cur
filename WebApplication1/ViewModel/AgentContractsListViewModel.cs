using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class AgentContractsListViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
        public SelectList Agents { get; set; }
        public SelectList Months { get; set; }
        public double? SumContract { get; set; }
        public double? SumComission { get; set; }
    }
}