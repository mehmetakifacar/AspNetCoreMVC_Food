using AspNetCoreMVC_Food.Data;
using AspNetCoreMVC_Food.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_Food.Controllers
{
    public class ChartController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View();
        }


        public List<Class1> FoodList()
        {
            List<Class1> list = new List<Class1>();
            using (var db = new Context())
            {
                list = db.Foods.Select(c => new Class1
                {
                    foodname = c.Name,
                    stock = c.Stock
                }).ToList();
            }

            return list;
        }


        public IActionResult VisualizeResult()
        {
            return Json(FoodList());
        }


        public IActionResult Index2()
        {
            return View();
        }


        public IActionResult Statistic()
        {
            var value1 = db.Foods.Count();
            ViewBag.vl1 = value1;

            var value2 = db.Categories.Count();
            ViewBag.vl2 = value2;

            var value3 = db.Foods.Where(c => c.CategoryId == db.Categories.Where(d => d.Name == "Fruits")
            .Select(e => e.CategoryId).FirstOrDefault()).Count();
            ViewBag.vl3 = value3;

            var value4 = db.Foods.Where(c => c.CategoryId == db.Categories.Where(d => d.Name == "Vegetables")
            .Select(e => e.CategoryId).FirstOrDefault()).Count();
            ViewBag.vl4 = value4;

            var value5 = db.Foods.Sum(c => c.Stock);
            ViewBag.vl5 = value5;

            var value6 = db.Foods.Where(c => c.CategoryId == db.Categories.Where(d => d.Name == "Legumes")
            .Select(e => e.CategoryId).FirstOrDefault()).Count();
            ViewBag.vl6 = value6;

            var value7 = db.Foods.Where(c => c.Stock == db.Foods.Max(d => d.Stock))
            .Select(e => e.Name).FirstOrDefault();
            ViewBag.vl7 = value7;

            var value8 = db.Foods.Where(c => c.Stock == db.Foods.Min(d => d.Stock))
            .Select(e => e.Name).FirstOrDefault();
            ViewBag.vl8 = value8;

            var value9 = db.Foods.Average(c => c.Price).ToString("0.00");
            ViewBag.vl9 = value9;

            var value10 = db.Categories.Where(c => c.Name == "Fruits").Select(d => d.CategoryId)
            .FirstOrDefault();
            var value010 = db.Foods.Where(c => c.CategoryId == value10).Sum(e => e.Stock);
            ViewBag.vl10 = value010;

            var value11 = db.Categories.Where(c => c.Name == "Vegetables").Select(d => d.CategoryId)
            .FirstOrDefault();
            var value011 = db.Foods.Where(c => c.CategoryId == value11).Sum(e => e.Stock);
            ViewBag.vl11 = value011;

            var value12 = db.Foods.Where(c => c.Price == db.Foods.Max(d => d.Price))
            .Select(e => e.Name).FirstOrDefault();
            ViewBag.vl12 = value12;

            return View();
        }


    }
}
