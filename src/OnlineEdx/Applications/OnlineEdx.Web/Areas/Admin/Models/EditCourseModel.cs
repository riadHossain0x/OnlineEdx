using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Validations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineEdx.Web.Areas.Admin.Models
{
	public class EditCourseModel : AdminBaseModel
	{
        public Guid Id { get; set; }

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
        private readonly ICategoryService _categoryService;

        public EditCourseModel()
		{

		}

		public EditCourseModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService,
            ICategoryService categoryService)
			: base(mapper, scope)
		{
			_courseService = courseService;
            _categoryService = categoryService;
        }

		public override void ResolveDependency(ILifetimeScope scope)
		{
			_scope = scope;
			_courseService = _scope.Resolve<ICourseService>();
			base.ResolveDependency(scope);
		}

        public void GetCourse(Guid id)
        {
            var course = _courseService.GetById(id);
            _mapper.Map(course, this);
            Categories = _categoryService.GetCategories().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
	}
}
