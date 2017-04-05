using Microsoft.EntityFrameworkCore;
 
namespace RestauranterApplication.Models
{
    public class RestauranterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestauranterContext(DbContextOptions<RestauranterContext> options) : base(options) { }
        public DbSet<Review> Review { get; set; }
    }
}