using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Models
{
    public class HomeModel : BaseModel
    {
        public List<Category> Categories { get; set; } = null!;

        private readonly ICategoryService _categoryService = null!;

        public HomeModel()
        {

        }

        public HomeModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
        }

        public void LoadData()
        {
            Categories = _categoryService.GetCategoryWiseCourse().ToList();
        }
    }
}
