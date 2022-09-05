using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Mapping
{
    public class EnrollMap : ClassMap<Enroll>
    {
        public EnrollMap()
        {
            Table("Enrolls");
            Id(x => x.EnrollId).GeneratedBy.Identity();
            References(x => x.Course)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("CourseId");
            References(x => x.ApplicationUser)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("ApplicationUserId");
        }
    }
}
