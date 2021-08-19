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
    }
}
