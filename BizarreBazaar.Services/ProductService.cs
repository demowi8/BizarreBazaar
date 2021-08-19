using BizarreBazaar.Data;
using BizarreBazaar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Services
{
    public class ProductService
    {
        private readonly Guid _userID;

        public ProductService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                OwnerID = _userID,
                Name = model.Name,
                Price = model.Price,
                InventoryCount = model.InventoryCount,
                Description = model.Description
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Products
                    .Where(e => e.OwnerID == _userID)
                    .Select(e => new ProductListItem
                    {
                        ProductID = e.ProductID,
                        Name = e.Name,
                        Price = e.Price,
                    });
                return query.ToArray();
                //This allows us to see all products per user
            }
        }
        public ProductDetail GetProductByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductID == id && e.OwnerID == _userID);
                return new ProductDetail
                {
                    ProductID = entity.ProductID,
                    Name = entity.Name,
                    Description = entity.Description,
                    InventoryCount = entity.InventoryCount,
                    Price = entity.Price
                };
            }
        }
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductID == model.ProductID && e.OwnerID == _userID);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.InventoryCount = model.InventoryCount;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Products
                    .Single(e => e.ProductID == productID && e.OwnerID == _userID);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
