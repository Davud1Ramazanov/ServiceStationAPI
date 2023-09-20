using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ServiceStationAPI.Configuration;
using ServiceStationAPI.Models;
using System.Security.Claims;

namespace ServiceStationAPI.LocalControllers
{
    public class OrderLocalController : IOrderController
    {
        private readonly DbContextClass serviceContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderLocalController(DbContextClass service, IHttpContextAccessor httpContextAccessor)
        {
            serviceContext = service;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<List<Order>> Create(Order t)
        {
            var item = serviceContext.Orders.FirstOrDefault(x => x.UserName.Equals(t.UserName));
            if (item == null)
            {
                serviceContext.Orders.Add(new Order {
                    OrderId = t.OrderId,
                    UserName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value
                });
                serviceContext.SaveChanges();
            }
            return serviceContext.Orders.ToListAsync();
        }

        public Task<List<Order>> Delete(int id)
        {
            var item = serviceContext.Orders.FirstOrDefault(x => x.OrderId.Equals(id));
            if (item != null)
            {
                serviceContext.Orders.Remove(item);
                serviceContext.SaveChanges();
            }
            return serviceContext.Orders.ToListAsync();
        }

        public Task<List<Order>> Edit(int id, string name)
        {
            var item = serviceContext.Orders.FirstOrDefault(x => x.OrderId.Equals(id));
            if (item != null)
            {
                item.UserName = name;
                serviceContext.SaveChanges();
            }
            return serviceContext.Orders.ToListAsync();
        }

        public Task<List<Order>> Select()
        {
            return serviceContext.Orders.ToListAsync();
        }

        public Task<List<Order>> SelectOrderUser()
        {
            var selectOrderName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            return serviceContext.Orders.Where(x => x.UserName.Equals(selectOrderName)).ToListAsync();
        }
    }
}
