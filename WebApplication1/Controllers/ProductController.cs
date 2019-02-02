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
    public class ProductController : Controller
    {
        public ActionResult ProductDiagramm()
        {
            return View();
        }

        public ActionResult EditCost(string vid, double? procent)
        {
            CurContext db = new CurContext();
            IQueryable<Product> productlist = db.Products;
            List<Product> vids = db.Products.ToList();
            vids.Insert(0, new Product { Vid = "Все", ID = 0 });
            if (!String.IsNullOrEmpty(vid) && !vid.Equals("Все"))
            {
                foreach (var product in db.Products.Where(t => t.Vid == vid))
                {
                    product.Cost+= (product.Cost *= (procent/100));
                }

                productlist = productlist.Where(p => p.Vid == vid);
            }
            db.SaveChanges();

            ProductsListViewModel tlvm = new ProductsListViewModel
            {
                Products = productlist.ToList(),
                Vids = new SelectList(vids, "Vid", "Vid"),
                Procent = procent
            };



            return View(tlvm);
        }

       

        public ActionResult Products()
        {
            ProductService productService = new ProductService();
            return View(productService.getList());
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            ProductService productService = new ProductService();

            if (id == null)
            {
                return HttpNotFound();
            }

            if (productService.findProductById(id) != null)
            {
                return View(productService.findProductById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            ProductService productService = new ProductService();
            productService.Edit(product);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            CurContext db = new CurContext();

            SelectList vids = new SelectList(new List<string>()
                {
                    "Строительные материалы",
                    "Канцелярские товары",
                    "Электроника"
                    
                });


            ViewBag.Vids = vids;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            ProductService productService = new ProductService();
            productService.Create(product);
            return RedirectToAction("Products");
        }

        public ActionResult DeleteProduct(int id)
        {
            ProductService productService = new ProductService();
            productService.Delete(id);
            return RedirectToAction("Products");
        }
    }
}