using Domain.Repositories;
using Infrastructure.Data;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork(AppDBContext context, ITicketRepository ticketRepository, IDiscussionRepository discussionRepository) : IUnitOfWork
    {
        private Hashtable? _repositories;
        private bool _disposed = false;

        public ITicketRepository TicketRepository => ticketRepository;

        public IDiscussionRepository DiscussionRepository => discussionRepository;

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<T>(context);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<T>)_repositories[type]!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesReturnBoolAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
