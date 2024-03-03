using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            List<SelectListItem> values = (from x in context.Abouts.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.AboutId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About a)
        {

            context.Abouts.Add(a);
            context.SaveChanges();
            return RedirectToAction("AboutList");

        }
        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);

            List<SelectListItem> abouts = (from x in context.Abouts.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Title,
                                              Value = x.AboutId.ToString()
                                          }).ToList();
            ViewBag.v = abouts;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About a)
        {
            var value = context.Abouts.Find(a.AboutId);
            value.AboutId = a.AboutId;
            value.Title = a.Title;
            value.ImageUrl = a.ImageUrl;
           
            value.Description = a.Description;
            context.SaveChanges();
            return RedirectToAction("AboutList");


        }
    }
}