﻿namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository TicketRepository { get; }
        IDiscussionRepository DiscussionRepository { get; }
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task<bool> SaveChangesReturnBoolAsync();
    }
}
