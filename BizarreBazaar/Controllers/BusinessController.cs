using BizarreBazaar.Models.Business_Models;
using BizarreBazaar.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizarreBazaar.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BusinessService(userID);
            var model = service.GetBusinesses();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBusinessService();

            if (service.CreateBusiness(model))
            {
                TempData["SaveResult"] = "Your business was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Business could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateBusinessService();
            var detail = service.GetBusinessByID(id);
            var model = new BusinessEdit
            {
                BusinessID = detail.BusinessID,
                Name = detail.Name,
                PhoneNumber = detail.PhoneNumber,
                EmailAddress = detail.EmailAddress
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BusinessEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BusinessID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateBusinessService();

            if (service.UpdateBusiness(model))
            {
                TempData["SaveResult"] = "Your business was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your business could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBusinessService();
            service.DeleteBusiness(id);
            TempData["SaveResult"] = "Your Business was deleted.";

            return RedirectToAction("Index");
        }
        private BusinessService CreateBusinessService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BusinessService(userID);

            return service;
        }
    }
}