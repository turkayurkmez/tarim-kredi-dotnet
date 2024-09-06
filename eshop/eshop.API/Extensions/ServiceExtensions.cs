using eshop.API.Services;
using eshop.Application.Contract.Repositories;
using eshop.Application.Features.Products.Queries.GetAllProducts;
using eshop.Persistence.Data;
using eshop.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eshop.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInstances(this IServiceCollection services, string? connectionString)
        {

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetProductsQueryHandler).Assembly));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;

        }
    }
}
