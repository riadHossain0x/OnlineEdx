using Autofac;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<LogoutModel>().AsSelf();
            builder.RegisterType<CreateCategoryModel>().AsSelf();
            builder.RegisterType<GetCategoriesModel>().AsSelf();
            builder.RegisterType<DeleteCategoryModel>().AsSelf();
            builder.RegisterType<EditCategoryModel>().AsSelf();
            builder.RegisterType<CreateCourseModel>().AsSelf();
            builder.RegisterType<EditCourseModel>().AsSelf();
            builder.RegisterType<GetCoursesModel>().AsSelf();
            base.Load(builder);
        }
    }
}
