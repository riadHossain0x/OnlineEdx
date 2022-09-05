using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Services
{
    public interface IEnrollmentService
    {
        void EnrollCourseAsync(Guid courseId, ApplicationUser user);
        IList<Course> GetEnrolledCourses(Guid userId);
    }
}
