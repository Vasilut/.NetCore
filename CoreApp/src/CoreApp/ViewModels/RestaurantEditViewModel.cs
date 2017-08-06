using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
