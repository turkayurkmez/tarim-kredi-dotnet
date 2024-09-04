using eshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Contract.Repositories
{
    public interface IProductRepository : IRepository<Product> 
    {
        //Eğer koleksiyona yeni bir nesne eklemeyeceksem. Sadece foreach gibi döngüler ile koleksiyonda döneceksem. IEnumerable bana yeter.
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
    }
}
