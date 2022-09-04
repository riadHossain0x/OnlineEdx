using Autofac;
using AutoMapper;
using FluentNHibernate.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Validations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineEdx.Web.Areas.Admin.Models
{
	public class CreateCourseModel : AdminBaseModel
	{
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [MaxFileSize(200)]
        [FileType(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Preview Video Url")]
        public string PreviewVideo { get; set; } = null!;
		public List<SelectListItem>? Categories { get; set; } = null!;

		[Required]
		[Display(Name = "Category")]
		public Guid CategoryId { get; set; }
		public string? Image { get; set; } = null!;

		private ICourseService _courseService = null!;
		private ICategoryService _categoryService = null!;
		private IFileService _fileService = null!;

		public CreateCourseModel()
		{

		}

		public CreateCourseModel(IMapper mapper, ILifetimeScope scope, 
			ICourseService courseService, ICategoryService categoryService, IFileService fileService)
			: base(mapper, scope)
		{
			_courseService = courseService;
			_categoryService = categoryService;
			_fileService = fileService;
		}

		public override void ResolveDependency(ILifetimeScope scope)
		{
			_scope = scope;
			_courseService = _scope.Resolve<ICourseService>();
			_categoryService = _scope.Resolve<ICategoryService>();
			_fileService = _scope.Resolve<IFileService>();
			base.ResolveDependency(scope);
		}

		public void GetCategoris()
		{
			Categories = _categoryService.GetCategories().Select(x => new SelectListItem
			{
				Text = x.Name,
				Value = x.Id.ToString()
			}).ToList();
        }

		public async Task CreateCourse()
		{
            Image = await _fileService.StoreFileAsync(ImageUrl);
            var course = _mapper.Map<Course>(this);
			_courseService.Add(course);
		}
	}
}
