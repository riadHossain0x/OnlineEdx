using Autofac;
using AutoMapper;
using FluentNHibernate.Mapping;
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
        [Display(Name = "Video Preview")]
        public string PreviewVideo { get; set; } = null!;

		[Required]
		public int CategoryId { get; set; }
		public string? Image { get; set; } = null!;

		private ICourseService _courseService = null!;

		public CreateCourseModel()
		{

		}

		public CreateCourseModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
			: base(mapper, scope)
		{
			_courseService = courseService;
		}

		public override void ResolveDependency(ILifetimeScope scope)
		{
			_scope = scope;
			_courseService = _scope.Resolve<ICourseService>();
			base.ResolveDependency(scope);
		}

	}
}
