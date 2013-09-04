using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMobile.Controllers
{
    public class ProductsController : Controller
    {
        readonly Repositories.ProductsRepository _products = new Repositories.ProductsRepository();

        public ActionResult Index(int id)
        {
            var products = _products.Get(id);

            return View(products);
        }

        [HttpPost]
        public ActionResult Update(Models.Product product) {

            if (ModelState.IsValid) {
                product = _products.Update(product);
                ViewBag.Status = "Success";
            } else {
                ViewBag.Status = "Error";
                ViewBag.Message = "Invalid Model";
            }

            return View("Index", product);
        }

    }
}
