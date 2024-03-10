using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class TestimonialController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult TestimonialList()
        {
            var values = context.Testimonials.ToList();
            return View(values);
           
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            List<SelectListItem> values = (from x in context.Testimonials.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.TestimonialId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial p)
        {
           
            context.Testimonials.Add(p);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);

            List<SelectListItem> testimonials = (from x in context.Testimonials.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NameSurname,
                                                   Value = x.TestimonialId.ToString()
                                               }).ToList();
            ViewBag.v = testimonials;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial p)
        {
            var value = context.Testimonials.Find(p.TestimonialId);
            value.TestimonialId = p.TestimonialId;
            value.NameSurname = p.NameSurname;
            value.ImageUrl = p.ImageUrl;
            value.Title= p.Title;
            value.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");


        }
        public ActionResult DetayTestimonial()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

    }
}