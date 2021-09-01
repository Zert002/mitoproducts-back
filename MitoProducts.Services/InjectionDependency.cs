using Microsoft.Extensions.DependencyInjection;
using MitoProducts.DataAccess;
using MitoProducts.DataAccess.Repositories;
using MitoProducts.Services.Implementations;
using MitoProducts.Services.Interfaces;

namespace MitoProducts.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            //return services.AddScoped<ICategoryRepository, CategoryRepository>()
            //    .AddScoped<ICategoryService, CategoryService>();
            return
                services
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>();
        }
    }
}
