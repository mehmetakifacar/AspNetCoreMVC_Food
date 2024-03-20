using AspNetCoreMVC_Food.Data.Models;
using AspNetCoreMVC_Food.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AspNetCoreMVC_Food.Controllers
{
    public class FoodController : Controller
    {
        Context db = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 3));//To List Category Names into view of food, we sent here a parameter of "Category" which represents Category class.
        }


        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.CategoryId.ToString()
                                               }).ToList();
            ViewBag.values = categories;

            return View();

        }


        [HttpPost]
        public IActionResult FoodAdd(AddProduct p)
        {
            Food food = new Food();
            if (p.ImageUrl != null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newPicName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures/", newPicName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                food.ImageUrl = newPicName;
            }
            food.Name = p.Name;
            food.Price = p.Price;
            food.Description = p.Description;
            food.CategoryId = p.CategoryId;
            food.Stock = p.Stock;

            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult FoodUpdate(int id)
        {
            var update = foodRepository.TGet(id);

            List<SelectListItem> categories = (from i in db.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.CategoryId.ToString()
                                               }).ToList();
            ViewBag.values = categories;

            Food food = new Food()
            {
                FoodId = update.FoodId,
                CategoryId = update.CategoryId,
                Name = update.Name,
                Description = update.Description,
                Price = update.Price,
                Stock = update.Stock,
                ImageUrl = update.ImageUrl
            };

            return View(food);
        }


        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var updated = foodRepository.TGet(p.FoodId);
            updated.Name = p.Name;
            updated.Description = p.Description;
            updated.Price = p.Price;
            updated.Stock = p.Stock;
            updated.ImageUrl = p.ImageUrl;
            updated.CategoryId = p.CategoryId;
            foodRepository.TUpdate(updated);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            foodRepository.TRemove(new Food { FoodId = id });
            return RedirectToAction("Index");
        }



    }
}
