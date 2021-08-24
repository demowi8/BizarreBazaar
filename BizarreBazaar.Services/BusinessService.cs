using BizarreBazaar.Data;
using BizarreBazaar.Models;
using BizarreBazaar.Models.Business_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Services
{
    public class BusinessService
    {
        private readonly Guid _userID;

        public BusinessService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateBusiness(BusinessCreate model)
        {
            var entity = new Business()
            {
                OwnerID = _userID,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Businesses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BusinessListItem> GetBusinesses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Businesses
                    .Where(e => e.OwnerID == _userID)
                    .Select(e => new BusinessListItem
                    {
                        BusinessID = e.BusinessID,
                        Name = e.Name,
                        PhoneNumber = e.PhoneNumber,
                        EmailAddress = e.EmailAddress
                    });
                return query.ToArray();
            }
        }
        public BusinessDetail GetBusinessByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Businesses
                    .Single(e => e.BusinessID == id && e.OwnerID == _userID);
                return new BusinessDetail
                {
                    BusinessID = entity.BusinessID,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    EmailAddress = entity.EmailAddress
                };
            }
        }
        public bool UpdateBusiness(BusinessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Businesses
                    .Single(e => e.BusinessID == model.BusinessID && e.OwnerID == _userID);

                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.EmailAddress = model.EmailAddress;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBusiness(int businessID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Businesses
                    .Single(e => e.BusinessID == businessID && e.OwnerID == _userID);

                ctx.Businesses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
