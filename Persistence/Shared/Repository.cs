using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbSet<T> DbSet;

        public Repository(DatabaseContext databaseContext)
        {
            DbSet = databaseContext.GetDbSet<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T Get(Guid id)
        {
            return DbSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}