﻿using eshop.Application.Contract.Repositories;
using eshop.Domain;
using eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace eshop.Persistence.Repositories
{
    public class ProductRepository(EshopDbContext dbContext) : IProductRepository
    {
        public async Task CreateAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.AsNoTracking()
                                                  .FirstOrDefaultAsync(p => p.Id == id);
            //product.Price *= 0.50m;

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
            //int last = pageNo + 2;
            var result = await dbContext.Products.ToListAsync();
            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            //dbContext.Products.FromSqlRaw("SELECT * FROM Products WHERE Name LIKE @name",)
            //return dbContext.Products.Select(p=>new Product() {Name=p.Name, Description=p.Description, Price=p.Price, Id=p.Id}).Where(p => p.Name.Contains(name)).AsEnumerable();

            return dbContext.Products.Where(p => p.Name.Contains(name)).AsEnumerable();

        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
