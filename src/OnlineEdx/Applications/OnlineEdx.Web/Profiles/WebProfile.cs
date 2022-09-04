using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.BusinessObjects.Membership;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<ApplicationUser, RegisterModel>().ReverseMap()
                .ConvertUsing(x => new ApplicationUser
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.Email,
                    Email = x.Email,
                    Password = x.Password
                });

            CreateMap<ApplicationUser, LoginModel>().ReverseMap();
            CreateMap<Category, CreateCategoryModel>().ReverseMap();
            CreateMap<Category, EditCategoryModel>().ReverseMap();
            CreateMap<Course, CreateCourseModel>().ReverseMap();
            CreateMap<Course, EditCourseModel>().ReverseMap();
            CreateMap<Course, CourseDetailsModel>().ReverseMap();
            CreateMap<Course, GetCoursesHomeModel>().ReverseMap();
        }
    }
}
