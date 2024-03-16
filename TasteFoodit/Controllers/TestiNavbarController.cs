using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class TestiNavbarController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialTestimonialNavbar()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

    }
}