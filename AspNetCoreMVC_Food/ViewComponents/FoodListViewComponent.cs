using AspNetCoreMVC_Food.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_Food.ViewComponents
{
    public class FoodListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodList = foodRepository.TList();

            return View(foodList);
        }
    }
}
