using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Mapping
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Image);
            Map(x => x.PreviewVideo);
        }
    }
}
