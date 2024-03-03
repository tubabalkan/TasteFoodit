using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class OpenDayHourController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult OpenDayList()
        {
            var values = context.OpenDayHours.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatOpenDayHour()
        {
            List<SelectListItem> values = (from x in context.OpenDayHours.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DayName,
                                               Value = x.OpenDayHourId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreatOpenDayHour(OpenDayHour c)
        {

            context.OpenDayHours.Add(c);
            context.SaveChanges();
            return RedirectToAction("OpenDayList");

        }
        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayList");
        }
        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);

            List<SelectListItem> days = (from x in context.OpenDayHours.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DayName,
                                              Value = x.OpenDayHourId.ToString()
                                          }).ToList();
            ViewBag.v = days;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour p)
        {
            var value = context.OpenDayHours.Find(p.OpenDayHourId);
            value.OpenDayHourId = p.OpenDayHourId;
            value.DayName = p.DayName;
            value.OpenHourRange = p.OpenHourRange;
           
            context.SaveChanges();
            return RedirectToAction("OpenDayList");
        }
    }
}