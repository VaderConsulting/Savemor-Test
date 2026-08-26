using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Savemor.Models;

namespace Savemor.Controllers
{
    public class ProductController : Controller
    {
        private SavemorDBContext db = new SavemorDBContext();

        //
        // GET: /Product/

        public ActionResult Index(int CategoryID = 0)
        {           
            // Get the top-level categories
            var Categories =
                from c in db.Category
                where c.Parent == 0
                orderby c.SortOrder
                select c;

            // Get the products for the selected category
            var Products =
                from p in db.Product
                join l in db.ProductCategory on p.ID equals l.ProductID
                select p;

                //from p in db.Product
                //where p.Active == true
                //orderby p.Name
                //select p;

            ProductsPageViewModel ppvm = new ProductsPageViewModel();

            ppvm.Category = Categories;
            ppvm.Product = Products;
            
            return View(ppvm);

            //return View(Products.ToList());
        }

        //
        // GET: /Product/

        public ActionResult Product(int id = 0)
        {
            return View(db.Product.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}