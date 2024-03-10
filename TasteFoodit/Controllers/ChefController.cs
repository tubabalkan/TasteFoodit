using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateChef()
        {
            List<SelectListItem> values = (from x in context.Chefs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.ChefId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateChef(Chef c)
        {

            context.Chefs.Add(c);
            context.SaveChanges();
            return RedirectToAction("ChefList");

        }
        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);

            List<SelectListItem> chefs = (from x in context.Chefs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.NameSurname,
                                                     Value = x.ChefId.ToString()
                                                 }).ToList();
            ViewBag.v = chefs;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef p)
        {
            var value = context.Chefs.Find(p.ChefId);
            value.ChefId = p.ChefId;
            value.NameSurname = p.NameSurname;
            value.ImageUrl = p.ImageUrl;
            value.Title = p.Title;
            value.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        public ActionResult DetayChef()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

    }
}