using eshop.Domain;
using Microsoft.EntityFrameworkCore;

namespace eshop.Persistence.Data
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=master;User ID=sa;Password=pa55W0rd;Encrypt=False;Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //bu ayarlar; db'yi doğrudan etkiler!
            //EF, çoğu ayarı otomatik yapabilir. Fakat biz yine de kontrolün bizde olması için aşağıdaki gibi derli toplu bir yapılandırma yapabiliriz.
            // Fluent API
            modelBuilder.Entity<Product>()
                        .Property(p => p.Name).IsRequired()
                                              .HasMaxLength(150);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>()
                        .HasData(
                            new Category { Id = 1, Name = "Elektronik" },
                            new Category { Id = 2, Name = "Kırtasiye" }
                        );

            modelBuilder.Entity<Product>()
                    .HasData(
                        new Product { Id = 1, Name = "Telefon", CategoryId = 1, Description = "Açıklama T.", ImageUrl = "fotograf", Price = 100, Stock = 1 },
                        new Product { Id = 2, Name = "Laptop", CategoryId = 1, Description = "Açıklama L.", ImageUrl = "fotograf", Price = 100, Stock = 1 },
                         new Product { Id = 3, Name = "Defter", CategoryId = 2, Description = "Açıklama D.", ImageUrl = "fotograf", Price = 100, Stock = 1 },
                        new Product { Id = 4, Name = "Kalem", CategoryId = 2, Description = "Açıklama K.", ImageUrl = "fotograf", Price = 100, Stock = 1 }
                    );
            //Ctrl + K + D
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
