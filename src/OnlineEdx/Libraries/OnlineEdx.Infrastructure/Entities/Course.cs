using OnlineEdx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Entities
{
    public class Course : IEntity<int>
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual string Image { get; set; } = null!;
        public virtual string PreviewVideo { get; set; } = null!;
    }
}
