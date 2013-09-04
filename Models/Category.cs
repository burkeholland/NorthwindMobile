using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindMobile.Models {
    public class Category {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public byte[] Picture { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}