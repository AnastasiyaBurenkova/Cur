using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ClientService
    {
        CurContext db = new CurContext();

        public void Delete(int id)
        {
            Client b = db.Clients.Find(id);
            if (b != null)
            {
                db.Clients.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        public List<Client> getList()
        {
            return db.Clients.ToList();
        }

        public Client findClientById(int? id)
        {
            Client client = db.Clients.Find(id);
            return client;
        }

    }
}
    