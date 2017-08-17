using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Entities;

namespace CoreApp.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private FoodDbContext _dbContext;

        public SqlRestaurantData(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _dbContext.Add(newRestaurant);
            //_dbContext.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.ToList();
        }
    }
}
