﻿using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult EducationList()
        {
            var values = context.Education.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.EducationId);
            value.SubTitle = education.SubTitle;
            value.Title = education.Title;
            value.Description = education.Description;
            value.Department = education.Department;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}