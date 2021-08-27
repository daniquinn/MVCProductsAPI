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

        public DbSet<Products> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Products { Id = 1, Title = "Outros" },
                    new Products { Id = 2, Title = "Alimentos" },
                    new Products { Id = 3, Title = "Bebidas" }
                    );

            modelBuilder.Entity<Products>()
                .HasData(
                    new Products { Id = 1, Title = "Caderno", Price = 7.50M, CategoryId = 1, Description = "Apenas um caderno comum" },
                    new Products { Id = 2, Title = "Lápis", Price = 1.50M, CategoryId = 1, Description = "Apenas um lápis" },
                    new Products { Id = 3, Title = "Salgadinho", Price = 5.29M, CategoryId = 2, Description = "Apenas um salgadinho" }
                    );
        }
    }
}
