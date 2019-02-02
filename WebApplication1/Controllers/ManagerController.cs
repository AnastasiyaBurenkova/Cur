using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Managers()
        {
            ManagerService managerService = new ManagerService();
            return View(managerService.getList());
        }

        [HttpGet]
        public ActionResult CreateManager()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateManager(Manager manager)
        {
            ManagerService managerService = new ManagerService();
            managerService.Create(manager);
            return RedirectToAction("Managers");
        }
    }

}