using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceStationAPI.Configuration;
using ServiceStationAPI.Controllers;
using ServiceStationAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceStationAPI.LocalControllers
{
    public class CarLocalController : ICarController
    {
        private readonly DbContextClass serviceContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CarLocalController(DbContextClass service, IHttpContextAccessor httpContextAccessor)
        {
            serviceContext = service;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Car>> Create(Car t)
        {
            var item = await serviceContext.Cars.FirstOrDefaultAsync(x => x.Name.Equals(t.Name));
            if (item == null)
            {
                serviceContext.Cars.Add(new Car
                {
                    OwnerName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value,
                    Capacity = t.Capacity,
                    Model = t.Model,
                    Name = t.Name,
                    Number = t.Number,
                    Year = t.Year,
                    VIN = t.VIN
                });
                await serviceContext.SaveChangesAsync();
            }
            return await serviceContext.Cars.ToListAsync();
        }

        public async Task<List<Car>> Delete(int id)
        {
            var item = await serviceContext.Cars.FirstOrDefaultAsync(x => x.CarId.Equals(id));
            if (item != null)
            {
                serviceContext.Cars.Remove(item);
                await serviceContext.SaveChangesAsync();
            }
            return await serviceContext.Cars.ToListAsync();
        }

        public async Task<List<Car>> Edit(int id, string name)
        {
            var item = await serviceContext.Cars.FirstOrDefaultAsync(x => x.CarId.Equals(id));
            if (item != null)
            {
                item.Name = name;
                await serviceContext.SaveChangesAsync();
            }
            return await serviceContext.Cars.ToListAsync();
        }

        public Task<List<Car>> Select()
        {
            return serviceContext.Cars.ToListAsync();
        }

        public Task<List<Car>> SelectUserCar()
        {
            var ownerCar = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            return serviceContext.Cars.Where(x => x.OwnerName.Equals(ownerCar)).ToListAsync();
        }
    }
}
