using System;
using System.Collections.Generic;
using CoreApp.Entities;
using System.Linq;

namespace CoreApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name = "Marty" },
                new Restaurant {Id=2, Name = "Bricks" },
                new Restaurant {Id=3, Name= "Hugo" }
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }


    }
}
