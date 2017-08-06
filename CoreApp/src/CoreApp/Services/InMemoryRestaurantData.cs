using System.Collections.Generic;
using CoreApp.Entities;

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
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }


    }
}
