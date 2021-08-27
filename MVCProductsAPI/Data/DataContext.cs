using Microsoft.EntityFrameworkCore;
using MVCProductsAPI.Models;

namespace MVCProductsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Product { Id = 1, Title = "Outros" },
                    new Product { Id = 2, Title = "Alimentos" },
                    new Product { Id = 3, Title = "Bebidas" }
                    );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Title = "Caderno", Price = 7.50M, CategoryId = 1, Description = "Apenas um caderno comum" },
                    new Product { Id = 2, Title = "Lápis", Price = 1.50M, CategoryId = 1, Description = "Apenas um lápis" },
                    new Product { Id = 3, Title = "Salgadinho", Price = 5.29M, CategoryId = 2, Description = "Apenas um salgadinho" }
                    );
        }
    }
}
