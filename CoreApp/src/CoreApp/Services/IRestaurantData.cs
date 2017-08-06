using CoreApp.Entities;
using System.Collections.Generic;

namespace CoreApp.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
