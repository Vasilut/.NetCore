using System;
using System.Collections.Generic;
using CoreApp.Entities;
using System.Linq;

namespace CoreApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData() //is static just for test purpose
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name = "Marty" },
                new Restaurant {Id=2, Name = "Bricks" },
                new Restaurant {Id=3, Name= "Hugo" }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(x => x.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public void Commit()
        {
            //no op
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
