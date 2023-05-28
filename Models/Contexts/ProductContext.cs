using Santa_Final_ASP.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Santa_Final_ASP.Models.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
