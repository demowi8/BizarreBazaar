using BizarreBazaar.Models;
using BizarreBazaar.Models.Auction_Models;
using BizarreBazaar.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizarreBazaar.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AuctionService(userID);
            var model = service.GetAuctions();

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
        public ActionResult Create(AuctionCreate auction)
        {
            if (!ModelState.IsValid) return View(auction);

            var service = CreateAuctionService();

            if(service.AuctionCreate(auction))
            {
                TempData["SaveResult"] = "Your Auction was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Auction could not be created.");

            return View(auction);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateAuctionService();
            var model = svc.GetAuctionByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAuctionService();
            var detail = service.GetAuctionByID(id);
            var model = new AuctionEdit
            {
                //ProductID = detail.ProductID,
                //Name = detail.Name,
                //Description = detail.Description,
                //InventoryCount = detail.InventoryCount,
                //Price = detail.Price,
                //StartingBid = detail.StartingBid
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuctionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AuctionID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateAuctionService();

            if(service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your Auction was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your auction could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateAuctionService();
            var model = svc.GetAuctionByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAuctionService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your auction was deleted.";

            return RedirectToAction("Index");
        }

        private ProductService CreateAuctionService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AuctionService(userID);
            return service;
        }
    }
}