using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Write
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}