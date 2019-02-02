using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Clients()
        {
            ClientService clientService = new ClientService();
            return View(clientService.getList());
        }

        [HttpGet]
        public ActionResult EditClient(int? id)
        {
            ClientService clientService = new ClientService();

            if (id == null)
            {
                return HttpNotFound();
            }

            if (clientService.findClientById(id) != null)
            {
                return View(clientService.findClientById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateClient(Client client)
        {
            ClientService clientService = new ClientService();
            clientService.Edit(client);
            return RedirectToAction("Clients");
        }

        [HttpGet]
        public ActionResult CreateClient()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(Client client)
        {
            ClientService clientService = new ClientService();
            clientService.Create(client);
            return RedirectToAction("Clients");
        }

        public ActionResult DeleteClient(int id)
        {
            ClientService clientService = new ClientService();
            clientService.Delete(id);
            return RedirectToAction("Clients");
        }
    }
}