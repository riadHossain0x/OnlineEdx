using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Entities
{
    public class Course : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual string Image { get; set; } = null!; 
        public virtual string PreviewVideo { get; set; } = null!;
        public virtual Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual List<Enroll> Enrolls { get; set; } = null!;
    }
}
