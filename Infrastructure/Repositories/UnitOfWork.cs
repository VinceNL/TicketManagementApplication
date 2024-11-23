using Domain.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext _context;
        private Hashtable? _repositories;

        public UnitOfWork(IdentityDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = repositoryType.MakeGenericType(typeof(T));
                var repository = new GenericRepository<T>(_context);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<T>)_repositories[type]!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesReturnBoolAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
