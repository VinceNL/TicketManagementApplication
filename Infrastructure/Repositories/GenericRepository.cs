using Domain.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IdentityDbContext _context;
        public GenericRepository(IdentityDbContext context)
        {
            _context = context;
        }
        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id) ?? throw new Exception("Entity not found");
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
