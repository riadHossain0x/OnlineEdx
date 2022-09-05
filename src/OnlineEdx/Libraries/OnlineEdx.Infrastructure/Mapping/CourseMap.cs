using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Mapping
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(x => x.Id).Column("Id").GeneratedBy.Guid();
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Image);
            Map(x => x.PreviewVideo);
            References(x => x.Category).Column("CategoryId");
            HasMany(x => x.Enrolls).KeyColumn("CourseId")
                .Fetch.Join()
                .Inverse()
                .Cascade.All();
        }
    }
}
