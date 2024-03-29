﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodit.Entities;
using TasteFoodit.Context;
using TasteFoodit.Models;

namespace TasteFoodit.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.Phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.Email = context.Addresses.Select(y => y.Email).FirstOrDefault();
            ViewBag.Description = context.Addresses.Select(z => z.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialSlider()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialMenu()
        {
            var values = context.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
            
        }
        public PartialViewResult PartialPerfect()
        {
            return PartialView();
        }
        public PartialViewResult PartialTasteit()
        {
            var values = context.SocialMedias.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialOpenHours()
        {
            var values = context.OpenDayHours.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialInstagramImage()
        {
            return PartialView();
        }
        public PartialViewResult PartialBulten()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult PartialRzr()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialRzr(ReservationModel r)
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