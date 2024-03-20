using AspNetCoreMVC_Food.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_Food.ViewComponents
{
    public class FoodListCtgViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodListCtg = foodRepository.List(c => c.CategoryId == id);

            return View(foodListCtg);
        }
    }
}
