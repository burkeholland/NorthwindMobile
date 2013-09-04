using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindMobile.Repositories {
    
    public class CategoriesRepository {

        readonly Data.NorthwindEntities _entities = new Data.NorthwindEntities();

        public Models.Category Get(int id) {
            var categories = Get();
            return categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public IQueryable<Models.Category> Get() {
            var categories = _entities.Categories.Select(c =>
                  new Models.Category {
                      CategoryId = c.Category_ID,
                      CategoryName = c.Category_Name,
                      CategoryDescription = c.Description,
                      Picture = c.Picture,
                      Products = c.Products.Select(p =>
                          new Models.Product {
                              ProductId = p.Product_ID,
                              Discontinued = p.Discontinued,
                              ProductName = p.Product_Name,
                              QuantityPerUnit = p.Quantity_Per_Unit,
                              ReorderLevel = p.Reorder_Level,
                              SupplierId = p.Supplier_ID,
                              UnitPrice = p.Unit_Price,
                              UnitsInStock = p.Units_In_Stock,
                              UnitsOnOrder = p.Units_On_Order
                          })
                  });

            return categories;

        }
    }
}