using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.MVC.Services;
using SuperMarket.MVC.Models;

namespace SuperMarket.MVC.Controllers
{
    public class ProductCategoriesController : Controller
    {
        // GET: ProductCategories
        public ActionResult Index()
        {
            ProductCategoriesService service = new ProductCategoriesService();
            ViewBag.listProductCategories = service.Retrieve();
            return View();
        }

        // GET: ProductCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        [HttpPost]
        public ActionResult Create(ProductCategory pc)
        {
            try
            {
                ProductCategoriesService service = new ProductCategoriesService();
                service.Create(pc);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
