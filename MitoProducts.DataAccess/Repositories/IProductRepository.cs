using MitoProductos.Entities;
using MitoProducts.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MitoProducts.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<int> CreateAsync(Product entity);
        Task DeleteAsync(int id);
        Task<(ICollection<ProductInfo> collection, int total)> GetCollectionAsync(string filter, int page, int rows);
        Task<(ICollection<ProductInfo> collection, int total)> List(Expression<Func<Product, bool>> predicate, int page, int rows);
        Task<Product> GetItemAsync(int id);
        Task UpdateAsync(Product entity);
    }
}
