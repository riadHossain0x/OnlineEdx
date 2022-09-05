using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Services
{
    public interface IEnrollmentService
    {
        void EnrollCourseAsync(Guid courseId, ApplicationUser user);
        IList<Course> GetEnrolledCourses(Guid userId);
        Task<(int total, int totalDisplay, IList<EnrollStudent> records)> GetEnrolledUsersAsync(
            int pageIndex, int pageSize, string searchText, string orderBy);
    }
}
