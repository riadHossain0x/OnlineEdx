using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class EditCategoryModel : AdminBaseModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        [MaxLength(250)]
        public string Description { get; set; } = null!;

        [MaxFileSize(200)]
        [FileType(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        [Display(Name = "Image")]
        public IFormFile? ImageUrl { get; set; } = null!;
        public string Image { get; set; } = null!;

        private ICategoryService _categoryService = null!;
        private IFileService _fileService = null!;

        public EditCategoryModel()
        {

        }

        public EditCategoryModel(IMapper mapper, ILifetimeScope scope, 
            ICategoryService categoryService, IFileService fileService)
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

        public void GetCategory(Guid id)
        {
            var category = _categoryService.GetById(id);

            _mapper.Map(category, this);
        }

        public async Task UpdateCategoryAsync()
        {
            if (ImageUrl != null)
                Image = await _fileService.StoreFileAsync(ImageUrl);

            var category = _mapper.Map<Category>(this);
            _categoryService.Update(category);
        }
    }
}
