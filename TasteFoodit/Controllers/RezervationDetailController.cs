using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Context;
using TasteFoodit.Entities;
using TasteFoodit.Models;

namespace TasteFoodit.Controllers
{
    public class RezervationDetailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialRezervasyon()
        {

            return PartialView();
        }
      
        [HttpPost]
        public PartialViewResult PartialRezervasyon(ReservationModel r)
        {
            Reservation reservation = new Reservation()
            {
                Name = r.Name,
                Email = r.Email,
                Phone = r.Phone,
                GuestCount = r.GuestCount,
                ReservationDate = DateTime.Parse($"{r.ReservationDate.Split('/')[2]}-{r.ReservationDate.Split('/')[0]}-{r.ReservationDate.Split('/')[1]}"),
                Time = r.Time
            };
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return PartialView();
        }
    }
}