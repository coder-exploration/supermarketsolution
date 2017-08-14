using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.MVC.Services;
using SuperMarket.MVC.Models;
using PagedList;

namespace SuperMarket.MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(int? categoryId, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SelectedCategoryId = categoryId;
            ProductsService service = new ProductsService();
            var products = service.Retrieve((categoryId ?? -1));
            switch (sortOrder)
            {
                case "Quantity":
                    products = products.OrderByDescending(p => p.QuantityAvailable);
                    break;
                case "Price":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderByDescending(p => p.Name);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            ViewBag.listProducts = products.ToPagedList(pageNumber, pageSize);

            return View(products.ToPagedList(pageNumber, pageSize));
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductsService service = new ProductsService();
            ViewBag.Product = service.RetrieveById(id);
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ProductCategoriesService service = new ProductCategoriesService();
            ViewBag.listProductCategories = service.Retrieve();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            try
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    HttpPostedFileBase productPhoto = Request.Files[0];
                    if (productPhoto.ContentLength > 0)
                    {
                        byte[] data = new byte[productPhoto.ContentLength];
                        productPhoto.InputStream.Read(data, 0, productPhoto.ContentLength);
                        p.Photo = data;
                    }
                }
                ProductsService service = new ProductsService();
                service.Create(p);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            try
            {

                if (Request.Files != null && Request.Files.Count > 0)
                {
                    HttpPostedFileBase productPhoto = Request.Files[0];
                    if (productPhoto.ContentLength > 0)
                    {
                        byte[] data = new byte[productPhoto.ContentLength];
                        productPhoto.InputStream.Read(data, 0, productPhoto.ContentLength);
                        p.Photo = data;
                    }
                }
                else
                {
                    p.Photo = Convert.FromBase64String(p.PhotoBase64);
                }
                ProductsService service = new ProductsService();
                service.Update(p.Id, p);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            ProductsService service = new ProductsService();
            service.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        // POST: Products/Delete/5
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
