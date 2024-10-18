using PortfolioDbNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioDbNight.Controllers
{
    public class PortfolioController : Controller
    {
       MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult PortfolioList()
        {
            var values = context.Portfolio.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }

        public ActionResult DeletePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            context.Portfolio.Remove(value);
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var value = context.Portfolio.Find(portfolio.PortfolioId);

            value.Category = portfolio.Category;
            value.Title = portfolio.Title;
            value.Description = portfolio.Description;
            value.ImageUrl = portfolio.ImageUrl;
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }
    }
}