using System;
using System.Web.Mvc;

namespace NorthwindMobile.Controllers
{
    public class CategoriesController : Controller
    {
        readonly Repositories.CategoriesRepository _categories = new Repositories.CategoriesRepository();

        public ActionResult Index(int categoryId) {

            var categories = _categories.Get(categoryId);

            return View(categories);
        }

    }
}
