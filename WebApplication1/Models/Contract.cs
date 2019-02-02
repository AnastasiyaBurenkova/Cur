using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Contract
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        //public double? CommissionAmount { get; set; }
        public double? Sum { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public string Vid { get; set; }
        public DateTime DateProduct { get; set; }
        public DateTime DateEndProduct { get; set; }
        public string ClientName { get; set; }
        public string ManagerName { get; set; }
        public string passportID { get; set; }
        public int Manager_ID { get; set; }
        public int Product_ID { get; set; }
        public int Client_ID { get; set; }
        public string Sclad { get; set; }
        public double? SumS { get; set; }
        public double? SumK { get; set; }
        public double? SumA { get; set; }

        public ICollection<Manager> Managers { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Product> Products { get; set; }
        public Contract()
        {
            Managers = new List<Manager>();
            Clients = new List<Client>();
            Products = new List<Product>();
        }
    }
}