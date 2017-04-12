using Microsoft.EntityFrameworkCore;
using ReactioAPI.Core.Domain;

namespace ReactioAPI.Core.Data
{
    public class ReactioContext : DbContext
    {
        public ReactioContext(DbContextOptions<ReactioContext> options) : base(options)
        {
        }

        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Substrate> Substrates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reaction>().ToTable("Reaction");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Substrate>().ToTable("Substrate");
        }
    }
}
