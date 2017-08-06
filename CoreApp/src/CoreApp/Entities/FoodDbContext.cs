using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions options) : base(options)
        {
            //add-migration "Initial-Create"
            //update-database
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
