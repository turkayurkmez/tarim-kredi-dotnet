using eshop.Application.Contract.Repositories;
using eshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products = new()
            {
                new Product{ Id = 1, Name="A", Description="A Açıklama", ImageUrl="", Price=1},
                new Product{ Id = 2, Name="B", Description="B Açıklama",   ImageUrl="", Price=2 },
                new Product{ Id = 3, Name="C", ImageUrl="", Price=3 },

            };
        public Task CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return products;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
