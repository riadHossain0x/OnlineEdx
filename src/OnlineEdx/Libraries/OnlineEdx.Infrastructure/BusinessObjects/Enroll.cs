using OnlineEdx.Data;
using OnlineEdx.Infrastructure.BusinessObjects.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.BusinessObjects
{
    public class Enroll
    {
        public virtual int Id { get; set; }
        public virtual Course Course { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
