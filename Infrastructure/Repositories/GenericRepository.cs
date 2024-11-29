using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDBContext context) : IGenericRepository<T> where T : class
    {
        public T GetByIdAsync(int id)
        {
            return context.Set<T>().Find(id) ?? throw new Exception("Entity not found");
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
