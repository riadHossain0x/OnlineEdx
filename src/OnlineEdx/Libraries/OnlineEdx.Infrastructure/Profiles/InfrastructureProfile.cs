using AutoMapper;
using ApplicationUserEO = OnlineEdx.Infrastructure.Entities.Membership.ApplicationUser;
using ApplicationUserBO = OnlineEdx.Infrastructure.BusinessObjects.Membership.ApplicationUser;
using CategoryEO = OnlineEdx.Infrastructure.Entities.Category;
using CategoryBO = OnlineEdx.Infrastructure.BusinessObjects.Category;

namespace OnlineEdx.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<ApplicationUserEO, ApplicationUserBO>().ReverseMap();
            CreateMap<CategoryBO, CategoryEO>().ReverseMap();
        }
    }
}
