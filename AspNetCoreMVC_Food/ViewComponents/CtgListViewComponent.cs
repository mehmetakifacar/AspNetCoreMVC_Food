using AspNetCoreMVC_Food.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_Food.ViewComponents
{
    public class CtgListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.TList();

            return View(categoryList);
        }
    }
}
