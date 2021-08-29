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
        // GET: Product
        public ActionResult ProductIndex()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userID);
            var model = service.GetProducts();

            return View(model);
        }
        //GET CREATE
        public ActionResult ProductCreate()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate(ProductCreate model)
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
        public ActionResult ProductDetails(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductByID(id);

            return View(model);
        }
        public ActionResult ProductEdit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductByID(id);
            var model = new ProductEdit
            {
                ProductID = detail.ProductID,
                Name = detail.Name,
                Description = detail.Description,
                InventoryCount = detail.InventoryCount,
                Price = detail.Price,
                StartingBid = detail.StartingBid
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProductID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateProductService();

            if(service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your Product was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }
        public ActionResult ProductDelete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your product was deleted.";

            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userID);
            return service;
        }
    }
}