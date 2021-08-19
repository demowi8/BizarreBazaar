using BizarreBazaar.Models;
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
            var model = new ProductListItem[0];
            return View(model);
        }
        //GET CREATE
        public ActionResult Create()
        {
            return View();
        }
    }
}