using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ProductService
    {
        CurContext db = new CurContext();

        public void Delete(int id)
        {
            Product b = db.Products.Find(id);
            if (b != null)
            {
                db.Products.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        //private Lazy<TouristAgencyContext> context = new Lazy<TouristAgencyContext>(() => new TouristAgencyContext());

        //private TouristAgencyContext Сontext => context.Value;

        public List<Product> getList()
        {
            return db.Products.ToList();
        }

        public Product findProductById(int? id)
        {
            Product product = db.Products.Find(id);
            return product;
        }

    }
}