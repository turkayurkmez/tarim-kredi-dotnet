using eshop.API.Models;

namespace eshop.API.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products = new List<Product>
            {
                new Product{ Id = 1, Name="A", Description="A Açıklama", ImageUrl="", Price=1},
                new Product{ Id = 2, Name="B", Description="B Açıklama",   ImageUrl="", Price=2 },
                new Product{ Id = 3, Name="C", ImageUrl="", Price=3 },

            };
        //Ctrl + K + D
        public Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }



        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id = 1, Name="A", Description="A Açıklama", ImageUrl="", Price=1},
                new Product{ Id = 2, Name="B", Description="B Açıklama",   ImageUrl="", Price=2 },
                 new Product{ Id = 3, Name="C", ImageUrl="", Price=3 },

            };
        }

        public List<Product> SearchByName(string name)
        {
           return products.Where(p=>p.Name.Contains(name)).ToList();    
        }
    }
}
