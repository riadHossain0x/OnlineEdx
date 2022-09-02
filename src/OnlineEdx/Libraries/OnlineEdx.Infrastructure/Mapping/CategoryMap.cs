using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Image);
            HasMany(x => x.Courses).KeyColumn("CategoryId").Inverse()
            .Cascade.All();
        }
    }

}
