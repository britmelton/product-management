using Microsoft.EntityFrameworkCore;

namespace catalog_infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ProductDto> Product { get; set; }
    }
}
