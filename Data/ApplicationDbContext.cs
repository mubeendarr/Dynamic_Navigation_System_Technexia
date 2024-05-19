using Microsoft.EntityFrameworkCore;
using NavigationSystem.Models;

namespace NavigationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NavigationCategory> NavigationCategory { get; set; }
     

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)

        {

        }

    }
    
}
