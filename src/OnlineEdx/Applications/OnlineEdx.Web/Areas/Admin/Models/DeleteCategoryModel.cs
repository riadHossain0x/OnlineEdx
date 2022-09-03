using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class DeleteCategoryModel : AdminBaseModel
    {
        private ICategoryService _categoryService = null!;

        public DeleteCategoryModel()
        {

        }

        public DeleteCategoryModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
        }

        public void DeleteCategory(Guid id)
        {
            _categoryService.RemoveById(id);
        }
    }
}
