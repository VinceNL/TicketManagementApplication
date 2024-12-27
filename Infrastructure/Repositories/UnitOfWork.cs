using Domain.Repositories;
using Infrastructure.Data;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork(AppDBContext context, ITicketRepository ticketRepository, IDiscussionRepository discussionRepository) : IUnitOfWork
    {
        private Hashtable? _repositories;

        public ITicketRepository TicketRepository { get; } = ticketRepository;

        public IDiscussionRepository DiscussionRepository { get; } = discussionRepository;

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = repositoryType.MakeGenericType(typeof(T));
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

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
