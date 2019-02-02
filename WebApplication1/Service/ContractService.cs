using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ContractService
    {
        CurContext db = new CurContext();

        public void Delete(int id)
        {
            Contract b = db.Contracts.Find(id);
            if (b != null)
            {
                db.Contracts.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Contract contract)
        {

            db.Entry(contract).State = EntityState.Modified;
            int productid = contract.Product_ID;
            int id = contract.ID;
            db.SaveChanges();

            double? cost = 0;
            foreach (var product in db.Products.Where(t => t.ID == productid))
            {
                cost = product.Cost;
            }
            foreach (var contracts in db.Contracts.Where(c => c.ID == id))
            {
                contracts.Sum = contracts.Count * cost;
            }
            db.SaveChanges();
            foreach (var contracts in db.Contracts.Where(p => p.ID == id))
            {
            //    contracts.CommissionAmount = contracts.Sum / 3;
            }
            db.SaveChanges();

        }


        public void Create(Contract contract)
        {
            contract.ClientName = "клиент";
            contract.ManagerName = "менеджер";
            contract.ProductName = "продукт";
            contract.passportID = "****.******";
            contract.DateProduct = DateTime.Now;
            contract.DateEndProduct = DateTime.Now;
            contract.Vid = "вид";
            contract.Sum = 1;
            //contract.CommissionAmount = 1;

            db.Contracts.Add(contract);
            db.SaveChanges();

            int id = contract.ID;
            int productid = contract.Product_ID;
            int clientid = contract.Client_ID;
            int agentid = contract.Manager_ID;
            using (CurContext db = new CurContext())
            {
                double? cost = 0;
                string productName = contract.ProductName;
                string clientName = contract.ClientName;
                string agentName = contract.ManagerName;
                string passportid = contract.passportID;
                DateTime dateProduct = contract.DateProduct;
                DateTime dateendProduct = contract.DateEndProduct;
                string vid = contract.Vid;

                foreach (var client in db.Clients.Where(cl => cl.ID == clientid))
                {
                    clientName = client.Name;
                    passportid = client.passportID;
                }
                foreach (var agent in db.Managers.Where(a => a.ID == agentid))
                {
                    agentName = agent.Name;
                }
                foreach (var Product in db.Products.Where(t => t.ID == productid))
                {
                    cost = Product.Cost;
                    productName = Product.Name;
                    dateProduct = Product.Date;
                    dateendProduct = Product.EndDate;
                    vid = Product.Vid;

                }
                foreach (var contracts in db.Contracts.Where(c => c.ID == id))
                {

                    contracts.ManagerName = agentName;
                    contracts.passportID = passportid;
                    contracts.ClientName = clientName;
                    contracts.ProductName = productName;
                    contracts.Vid = vid;
                    contracts.DateProduct = dateProduct;
                    contracts.DateEndProduct = dateendProduct;
                    contracts.Date = DateTime.Today;
                    contracts.Sum = contracts.Count * cost;
                    if (vid == "Строительные материалы")
                    {
                        contracts.SumS = contracts.Count * cost;
                    }
                    if (vid == "Канцелярские товары")
                    {
                        contracts.SumK = contracts.Count * cost;
                    }
                    if (vid == "Электроника")
                    {
                        contracts.SumA = contracts.Count * cost;
                    }
                }
                db.SaveChanges();
                foreach (var contracts in db.Contracts.Where(p => p.ID == id))
                {
                 //   contracts.CommissionAmount = contracts.Sum / 3;
                }
                db.SaveChanges();
            }



        }

        public List<Contract> getList()
        {
            return db.Contracts.ToList();
        }



        public Contract findContractById(int? id)
        {
            Contract contract = db.Contracts.Find(id);
            return contract;
        }
    }
}