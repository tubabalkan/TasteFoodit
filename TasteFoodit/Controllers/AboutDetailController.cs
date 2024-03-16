using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
namespace TasteFoodit.Controllers
{
    public class AboutDetailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {         
            return View();
        }
        public PartialViewResult PartialItatistic()
        {
            ViewBag.Category = context.Categories.Count();
            ViewBag.Product = context.Products.Count();
            ViewBag.Testimonial = context.Testimonials.Count();
            ViewBag.Chef = context.Chefs.Count();
            return PartialView();
        }
    }
}