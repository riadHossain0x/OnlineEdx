using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.BusinessObjects
{
    public class EnrollStudent
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; } = null!;
        public virtual string LastName { get; set; } = null!;
        public virtual string Email { get; set; } = null!;
        public virtual string CourseTitle { get; set; } = null!;
        public virtual string CourseCategory { get; set; } = null!;
    }
}
