using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class SliderController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult SliderList()
        {
            var values = context.Sliders.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSlider()
        {

            List<SelectListItem> values = (from x in context.Sliders.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SliderName,
                                               Value = x.SliderId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlider(Slider s)
        {
            int currentRecordCount = context.Sliders.Count();

            // Maksimum kayıt sayısını kontrol et (örneğin, 3)
            if (currentRecordCount < 3)
            {
                // Maksimuma ulaşılmadıysa yeni kaydı ekle
                context.Sliders.Add(s);
                context.SaveChanges();
                return RedirectToAction("SliderList");
            }
            else
            {
                // Maksimuma ulaşıldıysa kullanıcıyı uyarmak için bir işlem yapabilirsiniz
                ViewBag.ErrorMessage = "Maksimum kayıt sayısına ulaşıldı (3).";
                return View(s); // Kullanıcıya tekrar CreateSlider view'ini göster
            }



        }
        public ActionResult DeleteSlider(int id)
        {
            var value = context.Sliders.Find(id);
            context.Sliders.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var value = context.Sliders.Find(id);

            List<SelectListItem> sldr = (from x in context.Sliders.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.SliderName,
                                             Value = x.SliderId.ToString()
                                         }).ToList();
            ViewBag.v = sldr;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSlider(Slider s)
        {
            var value = context.Sliders.Find(s.SliderId);
            value.SliderId = s.SliderId;
            value.SliderName = s.SliderName;
            value.ImageUrl = s.ImageUrl;
            value.Description = s.Description;
            value.Title = s.Title;

            context.SaveChanges();
            return RedirectToAction("SliderList");


        }
    }
}