using BizarreBazaar.Data;
using BizarreBazaar.Models;
using BizarreBazaar.Models.Bid_Models;
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


        public ActionResult AddBid(BidCreate bid)
        {
            if (!ModelState.IsValid) return View();

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BidService(userID);

            if(service.CreateBid(bid))
            {
                TempData["SaveResult"] = "Your Bid was made.";
                return View();
            }
            ModelState.AddModelError("", "Bid couldn't be made.");

            return View();
        }


    }
}