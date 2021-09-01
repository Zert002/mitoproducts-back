using MitoProductos.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MitoProducts.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryContextBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MitoProductsDbContext context) : base(context)
        {

        }
        //private readonly MitoProductsDbContext _context;
        //private readonly MitoProductsDbContext _context;

        //public CategoryRepository(MitoProductsDbContext context)
        //{
        //    _context = context;
        //}
        //public CategoryRepository(DbContextOptionsBuilder<MitoProductsDbContext> context)
        //{
        //    _context = new MitoProductsDbContext(context.Options);
        //}



        //public async Task<ICollection<Category>> GetCollection(string filter)
        //{
        //    return await Task.FromResult(new List<Category>
        //    {
        //        new Category
        //        {
        //            Id = 1,
        //            Name = "Juguetes",
        //            Description = "Jueguetes nuevos"
        //        },
        //        new Category
        //        {
        //            Id = 2,
        //            Name = "Computadoras",
        //            Description = "Computadoras y Laptops"
        //        }
        //    });
        //}
        //public async Task<ICollection<Category>> GetCollectionAsync(string filter, int page, int rows)
        //{
        //    var collection = await _context.Categories
        //        .Where(x => x.Name.Contains(filter))
        //        .AsNoTracking()
        //        .ToListAsync();
        //    return collection;
        //}
        public async Task<(ICollection<Category> collection, int total)> GetCollectionAsync(string filter, int page, int rows)
        {
            //var query = _context.Categories
            //    .Where(x => x.Name.Contains(filter));

            //var collection = await query
            //    .OrderBy(x => x.Id)
            //    .Select(x => new {
            //        Category = x,
            //        Total = query.Select(x => x).Count()
            //    })
            //    .AsNoTracking()
            //    .Skip((page -1) * rows)
            //    .Take(rows)
            //    .ToListAsync();

            //return (collection.Select(x => x.Category).ToList(), collection.First().Total);
            return await base.ListCollection(x => x.Name.Contains(filter), page, rows);
        }

        public async Task<Category> GetItemAsync(int id)
        {
            //return await _context.Categories.FindAsync(id);
            return await base.Select(id);
        }
        public async Task<int> CreateAsync(Category entity)
        {
            //await _context.Set<Category>().AddAsync(entity);
            //await _context.SaveChangesAsync();

            //return entity;
            return await Context.Insert(entity);
        }

        public async Task UpdateAsync(Category entity)
        {
            //var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);

            //category.Name = entity.Name;
            //category.Description = entity.Description;

            ////_context.Categories.Attach(category);
            //_context.Set<Category>().Attach(category);
            //_context.Entry(category).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            await Context.UpdateEntity(entity);
        }

        public async Task DeleteAsync(int id)
        {
            //var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            //if(category != null)
            //{
            //     _context.Set<Category>().Remove(category);
            //    _context.Entry(category).State = EntityState.Deleted;
            //    await _context.SaveChangesAsync();
            //}
            await Context.Delete(new Category
            {
                Id = id
            });
        }
    }
}
