using AutoMapper;
using OnlineEdx.Infrastructure.Entities.Membership;
using ApplicationUserBO = OnlineEdx.Infrastructure.BusinessObjects.ApplicationUser;

namespace OnlineEdx.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserBO>().ReverseMap();
        }
    }
}
