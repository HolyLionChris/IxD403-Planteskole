using Microsoft.EntityFrameworkCore; //FirstOrDefaultAsync
using Microsoft.EntityFrameworkCore.ChangeTracking; //EntityEntry
using Planteskole.Domain.Models; //DomainObject
using Planteskole.Domain.Services; //Tasks
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject //generic so that we can use it for Plants, Template etc..
    {
        private readonly PlanteskoleDbContextFactory _contextFactory; //we use ContextFactory for it to be threadsafe

        public GenericDataService(PlanteskoleDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(PlanteskoleDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (PlanteskoleDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id); //entity id == parameter id
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (PlanteskoleDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id); //entity id == parameter id
                return entity; //if id is the same then return it
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (PlanteskoleDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync(); //entity id == parameter id
                return entities; //if id is the same then return list of entities
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (PlanteskoleDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id; //replaces the existing id T entity with the id of the entity
                
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
