using MitoProductos.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MitoProducts.DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        Task <int> CreateAsync(Category entity);
        Task DeleteAsync(int id);
        Task<(ICollection<Category> collection, int total)> GetCollectionAsync(string filter, int page, int rows);
        Task<Category> GetItemAsync(int id);
        Task UpdateAsync(Category entity);
    }
}