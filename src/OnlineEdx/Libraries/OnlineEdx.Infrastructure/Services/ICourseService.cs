using OnlineEdx.Infrastructure.BusinessObjects;
using System.Linq.Expressions;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICourseService
    {
        Course GetById(Guid id);
        Task<(int total, int totalDisplay, IList<Course> records)> GetCoursesAsync(int pageIndex,
            int pageSize, string searchText, string orderBy);
        void Add(Course category);
        void Update(Course entity);
        void RemoveById(Guid Id);
        Task<(int total, int totalDisplay, IList<Course> records)> GetCoursesAsync(string category, int pageIndex, int pageSize);
    }
}
