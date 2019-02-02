using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CurContext: DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
       
    }
}