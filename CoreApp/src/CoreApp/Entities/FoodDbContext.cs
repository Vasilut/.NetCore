using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Entities
{
    public class FoodDbContext : IdentityDbContext<User>
    {
        public FoodDbContext(DbContextOptions options) : base(options)
        {
            //add-migration "Initial-Create"
            //update-database
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
