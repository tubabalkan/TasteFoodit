﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodit.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult RezervasyonList()
        {
            return View();
        }
    }
}