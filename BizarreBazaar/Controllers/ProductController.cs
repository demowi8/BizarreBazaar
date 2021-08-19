using BizarreBazaar.Models;
using BizarreBazaar.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizarreBazaar.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        // GET: Product
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userID);
            var model = service.GetProducts();

            return View(model);
        }
        //GET CREATE
        public ActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if(service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Product could not be created.");

            return View(model);

        }

        private ProductService CreateProductService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userID);
            return service;
        }
    }
}