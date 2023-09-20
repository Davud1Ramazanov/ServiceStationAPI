using Microsoft.EntityFrameworkCore;
using ServiceStationAPI.Configuration;
using ServiceStationAPI.Models;

namespace ServiceStationAPI.LocalControllers
{
    public class CategoryLocalController : ICategoryController
    {
        private readonly DbContextClass serviceContext;

        public CategoryLocalController(DbContextClass service)
        {
            serviceContext = service;
        }

        public Task<List<Category>> Create(Category t)
        {
            var item = serviceContext.Categories.FirstOrDefault(x => x.Name.Equals(t.Name));
            if (item == null)
            {
                serviceContext.Categories.Add(t);
                serviceContext.SaveChanges();
            }
            return serviceContext.Categories.ToListAsync();
        }

        public Task<List<Category>> Delete(int id)
        {
            var item = serviceContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
            if (item != null)
            {
                serviceContext.Categories.Remove(item);
                serviceContext.SaveChanges();
            }
            return serviceContext.Categories.ToListAsync();
        }

        public Task<List<Category>> Edit(int id, string name)
        {
            var item = serviceContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
            if (item != null)
            {
                item.Name = name;
                serviceContext.SaveChanges();
            }
            return serviceContext.Categories.ToListAsync();
        }

        public Task<List<Category>> Select()
        {
            return serviceContext.Categories.ToListAsync();
        }
    }
}
