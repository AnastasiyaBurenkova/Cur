using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class ContractController : Controller
    {
        ContractService contractService = new ContractService();

        public ActionResult PrintContract(int? id)
        {
            if (contractService.findContractById(id) != null)
            {
                return View(contractService.findContractById(id));
            }
            return HttpNotFound();
        }
        public ActionResult PrintContract1(int? id)
        {
            if (contractService.findContractById(id) != null)
            {
                return View(contractService.findContractById(id));
            }
            return HttpNotFound();
        }
        public ActionResult PrintContractPdf(string id)
        {
            return new ActionAsPdf("PrintContract", new { id });
        }
        public ActionResult PrintContract1Pdf(string id)
        {
            return new ActionAsPdf("PrintContract1", new { id });
        }

        public ActionResult Contracts()
        {
            CurContext db = new CurContext();
            var contracts = contractService.getList();
            return View(contracts);
        }

        public ActionResult FindProductDate (string day, string month, string year, string day2, string month2, string year2, Contract contract)
        {
            CurContext db = new CurContext();

            IQueryable<Contract> contracts = db.Contracts;

            if ((!String.IsNullOrEmpty(day) && !day.Equals("Все")) & (!String.IsNullOrEmpty(month) && !month.Equals("Все")) &(!String.IsNullOrEmpty(year) && !year.Equals("Все"))& (!String.IsNullOrEmpty(day2) && !day2.Equals("Все")) & (!String.IsNullOrEmpty(month2) && !month2.Equals("Все")) & (!String.IsNullOrEmpty(year2) && !year2.Equals("Все")))
            {
                var m = int.Parse(month);
                var d = int.Parse(day);
                var y = int.Parse(year);
                var m2 = int.Parse(month2);
                var d2 = int.Parse(day2);
                var y2 = int.Parse(year2);
                contracts = contracts.Where((p => ((p.Date.Year > y) || ((p.Date.Year == y) & (p.Date.Month > m)) || ((p.Date.Year == y) & (p.Date.Month == m) & (p.Date.Day >= d)))&((p.Date.Year < y2) || ((p.Date.Year == y2) & (p.Date.Month < m2)) || ((p.Date.Year == y2) & (p.Date.Month == m2) & (p.Date.Day <= d2)))));
            }

        

            ProductDataListViewModel cclvm = new ProductDataListViewModel
            {
                Contracts = contracts.ToList(),
                Days = new SelectList(new List<string>()
                {
                     "Все",
                         "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12",
                    "13",
                    "14",
                    "15",
                    "16",
                    "17",
                    "18",
                    "19",
                    "20",
                    "21",
                    "22",
                    "23",
                    "24",
                    "25",
                    "26",
                    "27",
                    "28",
                    "29",
                    "30",
                    "31"
                   
              
                }),
                Months = new SelectList(new List<string>()
                {
                    "Все",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
                   
                }),
                Years = new SelectList(new List<string>()
                {
                     "Все",
                     "2017",
                    "2018",
                    "2019",
                   "2020"
                   
                })
            };

            return View(cclvm);
        }
        public ActionResult FindIDContract(string id, string name)
        {
            CurContext db = new CurContext();

            IQueryable<Product> products = db.Products;

            if (!String.IsNullOrEmpty(id) && !id.Equals("Все"))
            {
                products = products.Where(p => p.ID.ToString() == id);
            }
            List<Product> ids = db.Products.ToList();
            

            if (!String.IsNullOrEmpty(name) && !name.Equals("Все"))
            {
                products = products.Where(p => p.Name == name);
            }
            List<Product> names = db.Products.ToList();

            names.Insert(0, new Product { Name = "Все", ID = 0 });
            ContractsListViewModel cclvm = new ContractsListViewModel
            {
                Products = products.ToList(),



                


                Name = new SelectList(names, "Name", "Name"),
                ID = new SelectList(new List<string>()
                {
                    "Все",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12",
                     "13",
                    "14",
                    "15",
                    "16",
                    "17",
                    "18",
                    "19",
                    "20",
                    "21",
                    "22",
                    "23",
                    "24",
                    "25",
                    "26",
                    "27",
                    "28",
                    "29",
                    "30",
                    "31"
                })
                
            };

            return View(cclvm);
        }

        public ActionResult FindClientsVid(string vid, string month, Contract contract)
        {
            CurContext db = new CurContext();

            IQueryable<Contract> clients = db.Contracts;

            if (!String.IsNullOrEmpty(vid) && !vid.Equals("Все"))
            {
                clients = clients.Where(p => p.Vid == vid);
            }
            List<Product> vids = db.Products.ToList();

            vids.Insert(0, new Product { Vid = "Все", ID = 0 });

            if (!String.IsNullOrEmpty(month) && !month.Equals("Все"))
            {
                clients = clients.Where(p => p.DateProduct.Month.ToString() == month);
            }

            ClientVidListViewModel cclvm = new ClientVidListViewModel
            {
                Clients = clients.ToList(),

                Vids =  new SelectList(new List<string>()
                {
                    "Строительные материалы",
                    "Канцелярские товары",
                    "Электроника"

                }),
                Months = new SelectList(new List<string>()
                {
                    "Все",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
                })
            };

            return View(cclvm);
        }
        public ActionResult FindClientsVidS(string vid, string client, Contract contract)
        {
            CurContext db = new CurContext();

            IQueryable<Contract> contracts = db.Contracts;
            // if(contracts == contracts.(p => p.Vid == "Строительные материалы"))
            //  {
            //     contracts = contracts.Where(p => p.Vid == "Строительные материалы");

            // }


            List<double?> sums = new List<double?>();
            List<double?> sumk = new List<double?>();
            List<double?> suma = new List<double?>();
            List<Contract> vids = db.Contracts.ToList();

            vids.Insert(0, new Contract { Vid = "Все", ID = 0 });

            if (!String.IsNullOrEmpty(client) && !client.Equals("Все"))
            {
                contracts = contracts.Where(p => p.ClientName == client);
                sums = contracts.Select(p => p.SumS).ToList();
                sumk = contracts.Select(p => p.SumK).ToList();
                suma = contracts.Select(p => p.SumA).ToList();
            }
            List<Client> clients = db.Clients.ToList();

            clients.Insert(0, new Client { Name = "Все", ID = 0 });
            ClientVidSListViewModel cclvm = new ClientVidSListViewModel
            {
                Contracts = contracts.ToList(),

                Sums = sums.Sum(),
                Sumk = sumk.Sum(),
                Suma = suma.Sum(),

                //     Vids = new SelectList(new List<string>()
                //       {
                //          "Строительные материалы",
                //        "Канцелярские товары",
                //           "Электроника"
                //
                //    }),



                Clients = new SelectList(clients, "Name", "Name"),
            };

            return View(cclvm);
        }

        public ActionResult PrintListClients(string agent, string month)
        {
            return new ActionAsPdf("ListClients", new { agent, month });
        }

        public ActionResult ListClients(string agent, string month)
        {
            CurContext db = new CurContext();
            IQueryable<Contract> contracts = db.Contracts;

            if (!String.IsNullOrEmpty(agent) && !agent.Equals("Все"))
            {
                contracts = contracts.Where(p => p.ManagerName == agent);
            }

            if (!String.IsNullOrEmpty(month) && !month.Equals("Все"))
            {
                contracts = contracts.Where(p => p.Date.Month.ToString() == month);
            }
            AgentContractsListViewModel aclvm = new AgentContractsListViewModel
            {
                Contracts = contracts.ToList(),
            };

            return View(aclvm);

        }

        public ActionResult PrintContractsAgent(string agent, string month)
        {
            return new ActionAsPdf("PrintReportAgent", new { agent, month });
        }

        public ActionResult PrintReportAgent(string agent, string month)
        {
            CurContext db = new CurContext();
            IQueryable<Contract> contracts = db.Contracts;
            List<double?> sumcontract = new List<double?>();
            List<double?> sumcomission = new List<double?>();
            if (!String.IsNullOrEmpty(agent) && !agent.Equals("Все"))
            {
                contracts = contracts.Where(p => p.ManagerName == agent);
                sumcontract = contracts.Select(p => p.Sum).ToList();
              //  sumcomission = contracts.Select(p => p.CommissionAmount).ToList();
            }

            if (!String.IsNullOrEmpty(month) && !month.Equals("Все"))
            {
                contracts = contracts.Where(p => p.Date.Month.ToString() == month);
                sumcontract = contracts.Select(p => p.Sum).ToList();
                //sumcomission = contracts.Select(p => p.CommissionAmount).ToList();
            }
            AgentContractsListViewModel aclvm = new AgentContractsListViewModel
            {

                Contracts = contracts.ToList(),
                SumContract = sumcontract.Sum(),
                SumComission = sumcomission.Sum(),

            };
            return View(aclvm);
        }

        public ActionResult FindContractsAgent(string agent, string month, Manager manager)
        {
            CurContext db = new CurContext();
            IQueryable<Contract> contracts = db.Contracts;
            List<double?> sumcontract = new List<double?>();
            //List<double?> sumcomission = new List<double?>();
            if (!String.IsNullOrEmpty(agent) && !agent.Equals("Все"))
            {
                contracts = contracts.Where(p => p.ManagerName == agent);
                sumcontract = contracts.Select(p => p.Sum).ToList();
           //     sumcomission = contracts.Select(p => p.CommissionAmount).ToList();
            }

            List<Manager> agents = db.Managers.ToList();

            agents.Insert(0, new Manager { Name = "Все", ID = 0 });

            if (!String.IsNullOrEmpty(month) && !month.Equals("Все"))
            {
                contracts = contracts.Where(p => p.Date.Month.ToString() == month);
                sumcontract = contracts.Select(p => p.Sum).ToList();
        //        sumcomission = contracts.Select(p => p.CommissionAmount).ToList();
            }

            AgentContractsListViewModel aclvm = new AgentContractsListViewModel
            {

                Contracts = contracts.ToList(),
                SumContract = sumcontract.Sum(),
               // SumComission = sumcomission.Sum(),
                Agents = new SelectList(agents, "Name", "Name"),
                Months = new SelectList(new List<string>()
                {
                    "Все",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
                })
            };

            return View(aclvm);
        }


        [HttpGet]
        public ActionResult EditContract(int? id)
        {
            ContractService contractService = new ContractService();

            if (id == null)
            {
                return HttpNotFound();
            }

            if (contractService.findContractById(id) != null)
            {
                return View(contractService.findContractById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateContract(Contract contract)
        {
            ContractService contractService = new ContractService();
            contractService.Edit(contract);
            return RedirectToAction("Contracts");
        }



        [HttpGet]
        public ActionResult CreateContractOne()
        {
            CurContext db = new CurContext();
            SelectList clients = new SelectList(db.Clients, "Id", "Name");
            SelectList Products = new SelectList(db.Products, "ID", "Name");
            SelectList agents = new SelectList(db.Managers, "ID", "Name");
            ViewBag.Clients = clients;
            ViewBag.Products = Products;
            ViewBag.Managers = agents;
            return View();


        }
        [HttpPost]
        public ActionResult CreateContractOne(Contract contract)
        {
            ContractService contractService = new ContractService();
            contractService.Create(contract);
            return RedirectToAction("Contracts", new { id = contract.ID });
        }

        public ActionResult DeleteContract(int id)
        {
            ContractService contractService = new ContractService();
            contractService.Delete(id);
            return RedirectToAction("Contracts");
        }

    }
}