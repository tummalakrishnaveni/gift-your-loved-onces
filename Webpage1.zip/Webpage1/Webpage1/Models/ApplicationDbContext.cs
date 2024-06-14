using System.Data.Entity;

namespace Webpage1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
