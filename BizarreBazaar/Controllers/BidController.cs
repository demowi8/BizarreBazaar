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
    public class BidController : Controller
    {
        // GET: Bid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BidCreate()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BidCreateBid model)
        {
            if (!ModelState.IsValid) return View();

            var service = CreateBidService();

            if(service.CreateBid(model))
            {
                TempData["SaveResult"] = "Your Bid was made.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your bid could not be made");

            return View(model);
        }

        private BidService CreateBidService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BidService(userID);

            return service;
        }
    }
}