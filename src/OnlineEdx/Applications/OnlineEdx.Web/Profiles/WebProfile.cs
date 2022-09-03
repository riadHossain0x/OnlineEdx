using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
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

            CreateMap<LoginModel, ApplicationUser>().ReverseMap();
        }
    }
}
