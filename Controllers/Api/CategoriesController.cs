using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthwindMobile.Controllers.Api
{

    public class CategoriesController : ApiController
    {

        readonly Repositories.CategoriesRepository categories = new Repositories.CategoriesRepository();

        public IEnumerable<Models.Category> Get() {
            return categories.Get();
        }
    }
}
