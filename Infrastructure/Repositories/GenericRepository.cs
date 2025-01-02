using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDBContext context) : IGenericRepository<T> where T : class
    {
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found.");
            }
            return entity;
        }
        public List<T> ListAll()
        {
            return context.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
