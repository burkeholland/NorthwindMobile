using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindMobile.Repositories {
    
    public class ProductsRepository {

        readonly Data.NorthwindEntities _entities = new Data.NorthwindEntities();

        public Models.Product Get(int id) {

            var products = Get();

            return products.Where(p => p.ProductId == id).FirstOrDefault();

        }

        public IQueryable<Models.Product> Get() {

            return _entities.Products.Select(p =>
                 new Models.Product {
                     ProductId = p.Product_ID,
                     Category = new Models.Category {
                         CategoryId = p.Category.Category_ID,
                         CategoryName = p.Category.Category_Name,
                         CategoryDescription = p.Category.Description,
                         Picture = p.Category.Picture
                     },
                     Discontinued = p.Discontinued,
                     ProductName = p.Product_Name,
                     QuantityPerUnit = p.Quantity_Per_Unit,
                     ReorderLevel = p.Reorder_Level,
                     SupplierId = p.Supplier_ID,
                     UnitPrice = p.Unit_Price,
                     UnitsInStock = p.Units_In_Stock,
                     UnitsOnOrder = p.Units_On_Order,
                 });

        }

        public Models.Product Update(Models.Product product) {
            
            var productToUpdate = Get(product.ProductId);
            
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.QuantityPerUnit = product.QuantityPerUnit;
            productToUpdate.ReorderLevel = product.ReorderLevel;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitsOnOrder = product.UnitsOnOrder;

            _entities.SaveChanges();

            return productToUpdate;
        }

    }
}