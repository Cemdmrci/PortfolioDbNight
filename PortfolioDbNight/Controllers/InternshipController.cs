﻿using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class InternshipController : Controller
    {
        // GET: Internship
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternship(Internship internship)
        {
            context.Internship.Add(internship);
            context.SaveChanges();

            return RedirectToAction("InternshipList");
        }

        public ActionResult DeleteInternship(int id)
        {
            var value = context.Internship.Find(id);
            context.Internship.Remove(value);
            context.SaveChanges();

            return RedirectToAction("InternshipList");
        }

        [HttpGet]
        public ActionResult UpdateInternship(int id)
        {
            var value = context.Internship.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInternship(Internship internship)
        {
            var value = context.Internship.Find(internship.InternshipId);
            value.CompanyName = internship.CompanyName;
            value.Title = internship.Title;
            value.Description = internship.Description;
            value.StartDate = internship.StartDate;
            value.FinishDate = internship.FinishDate;
            value.ImageUrl = internship.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
    }
}