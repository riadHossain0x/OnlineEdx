using OnlineEdx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Entities
{
    public class Course : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Image { get; set; }
        public virtual string PreviewVideo { get; set; }
    }
}
