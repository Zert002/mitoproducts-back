using Microsoft.EntityFrameworkCore;
using MitoProductos.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MitoProducts.DataAccess
{
    public static class DbContextExtensions
    {
        public async static Task<int> Insert<TRequest>(this DbContext context,TRequest entity)
            where TRequest : EntityBase
        {
            await  context.Set<TRequest>().AddAsync(entity);
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();

            return entity.Id;
        }
        public static async Task UpdateEntity<TRequest>(this DbContext context, 
            TRequest entity)
            where TRequest : EntityBase
        {
            context.Set<TRequest>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public static async Task Delete<TRequest>(this DbContext context, 
            TRequest entity)
            where TRequest : EntityBase
        {
            var entidad = await context.Set<TRequest>()
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entidad == null) throw new Exception("No encontrado");

            context.Set<TRequest>().Remove(entidad);
            context.Entry(entidad).State = EntityState.Deleted;

            await context.SaveChangesAsync();
        }
    }
}
