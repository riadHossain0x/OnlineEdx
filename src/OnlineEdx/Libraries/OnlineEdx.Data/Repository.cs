﻿using NHibernate;
using OnlineEdx.Data;
using System.Linq.Expressions;

namespace OnlineEdx.Data
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public TEntity Get(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _session.Query<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _session.SaveAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Update(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }
    }
}