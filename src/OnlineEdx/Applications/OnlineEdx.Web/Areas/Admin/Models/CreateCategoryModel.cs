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
        public string? Image { get; set; } = null!;

        private ICategoryService _categoryService = null!;
        private IFileService _fileService = null!;

        public CreateCategoryModel()
        {

        }

        public CreateCategoryModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService,
            IFileService fileService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
            _fileService = fileService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
            _fileService = _scope.Resolve<IFileService>();
            base.ResolveDependency(scope);
        }

        internal async Task CreateCategory()
        {
            Image = await _fileService.StoreFileAsync(ImageUrl);
            var category = _mapper.Map<Category>(this);
            _categoryService.Add(category);
        }
    }
}
