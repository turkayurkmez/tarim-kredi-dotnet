using eshop.API.Models;

namespace eshop.API.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id = 1, Name="A", Description="A Açıklama", ImageUrl="", Price=1},
                new Product{ Id = 2, Name="B", Description="B Açıklama",   ImageUrl="", Price=2 },
                 new Product{ Id = 3, Name="C", ImageUrl="", Price=3 },

            };
        }
    }
}
