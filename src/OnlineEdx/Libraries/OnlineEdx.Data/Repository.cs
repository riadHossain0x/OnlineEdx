﻿using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using OnlineEdx.Data;
using System.Linq.Dynamic.Core;
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

        public async virtual Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(
            Expression<Func<TEntity, bool>> filter = null!, string orderBy = null!, int pageIndex = 1, int pageSize = 10)
        {
            IQueryable<TEntity> query = _session.Query<TEntity>();
            var total = query.Count();
            var totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return (await result.ToListAsync(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return (await result.ToListAsync(), total, totalDisplay);
            }

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

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }
    }
}