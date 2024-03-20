using AspNetCoreMVC_Food.Data.Models;
using AspNetCoreMVC_Food.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace AspNetCoreMVC_Food.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(c => c.Name == p));
            }

            return View(categoryRepository.TList());
        }


        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            //if (!ModelState.IsValid)   //Category adding cant actualize when I activate this part.Will be checked later.
            //{
            //    return View("CategoryAdd");
            //}

            categoryRepository.TAdd(p);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var update = categoryRepository.TGet(id);
            Category categoryUpdate = new Category()
            {
                Name = update.Name,
                Description = update.Description,
                CategoryId = update.CategoryId
            };

            return View(categoryUpdate);
        }


        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var updated = categoryRepository.TGet(p.CategoryId);
            updated.Name = p.Name;
            updated.Description = p.Description;
            updated.Status = true;
            categoryRepository.TUpdate(updated);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var delete = categoryRepository.TGet(id);
            delete.Status = false;
            categoryRepository.TUpdate(delete);
            
            return RedirectToAction("Index");
            
        }
                     
    }
}


