using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
namespace TasteFoodit.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult RezervasyonList()
        {
            var values =context.Reservations.ToList();
            return View(values);
        }
        public ActionResult RezervationTrue(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = true;
            context.SaveChanges();
            return RedirectToAction("RezervasyonList");
        }
        public ActionResult RezervationFalse(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = false;
            context.SaveChanges();
            return RedirectToAction("RezervasyonList");
        }
        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("RezervasyonList");
        }
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);

            List<SelectListItem> rzr = (from x in context.Reservations.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ReservationId.ToString()
                                           }).ToList();
            ViewBag.v = rzr;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReservation(Reservation r)
        {
            var value = context.Reservations.Find(r.ReservationId);
            value.Name = r.Name;
            value.Email = r.Email;
            value.Phone = r.Phone;
            value.ReservationDate = r.ReservationDate;
            value.Time = r.Time;
            value.GuestCount = r.GuestCount;
            value.ReservationStatus = r.ReservationStatus;
            

            context.SaveChanges();
            return RedirectToAction("RezervasyonList");
        }

    }
}