
namespace OnlineEdx.Infrastructure.BusinessObjects
{
	public class Course
	{
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual string Image { get; set; } = null!;
        public virtual string PreviewVideo { get; set; } = null!;
        public virtual Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual IList<Enroll>? Enrolls { get; set; } = null!;
    }
}
