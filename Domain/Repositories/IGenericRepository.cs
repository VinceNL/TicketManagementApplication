﻿namespace Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByIdAsync(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
