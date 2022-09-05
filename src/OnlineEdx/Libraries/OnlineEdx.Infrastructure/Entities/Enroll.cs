using OnlineEdx.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Entities
{
    public class Enroll
    {
        public virtual int EnrollId { get; set; }
        public virtual Course Course { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
