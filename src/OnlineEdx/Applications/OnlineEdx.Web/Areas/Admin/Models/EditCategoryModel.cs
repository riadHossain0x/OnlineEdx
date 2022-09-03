using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class EditCategoryModel : AdminBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile ImageUrl { get; set; } = null!;
        public string Image { get; set; } = null!;

        private ICategoryService _categoryService = null!;

        public EditCategoryModel()
        {

        }

        public EditCategoryModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
        }

        public void GetCategory(Guid id)
        {
            var category = _categoryService.GetById(id);
            _mapper.Map(category, this);
        }
    }
}
