using FluentNHibernate.Data;
using OnlineEdx.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICourseService
    {
        Course Get(int id);
        IQueryable<Course> GetAll();
        IQueryable<Course> Find(Expression<Func<Course, bool>> predicate);
        void Add(Course category);
        void Update(Course entity);
        void Remove(Course entity);
    }
}
