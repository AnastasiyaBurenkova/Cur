using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ManagerService
    {
        CurContext db = new CurContext();
        public void Create(Manager manager)
        {
            db.Managers.Add(manager);
            db.SaveChanges();
        }


        public Manager findManagerById(int? id)
        {
            Manager manager = db.Managers.Find(id);
            return manager;
        }

        public List<Manager> getList()
        {
            return db.Managers.ToList();
        }
    }
}