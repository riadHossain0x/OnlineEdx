using OnlineEdx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Entities
{
    public class Category : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual string Image { get; set; } = null!;
        public virtual IList<Course> Courses { get; set; } = null!;
    }
}
