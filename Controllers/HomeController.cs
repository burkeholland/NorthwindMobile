using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMobile.Controllers
{
    public class HomeController : Controller
    {
        readonly Repositories.CategoriesRepository _categories = new Repositories.CategoriesRepository();

        public ActionResult Index() {

            var categories = _categories.Get();

            return View(categories);
        }
    }
}
