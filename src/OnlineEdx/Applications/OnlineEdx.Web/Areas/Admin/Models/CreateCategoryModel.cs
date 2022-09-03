using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class CreateCategoryModel : AdminBaseModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [MaxFileSize(200)]
        [FileType(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; } = null!;

        private ICategoryService _categoryService = null!;

        public CreateCategoryModel()
        {

        }

        public CreateCategoryModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
            base.ResolveDependency(scope);
        }

        internal void CreateCategory()
        {
            var category = _mapper.Map<Category>(this);
            _categoryService.Add(category);
        }
    }
}
