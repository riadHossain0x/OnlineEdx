using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Areas.Admin.Models
{
	public class GetCoursesModel : AdminBaseModel
	{
		private readonly ICourseService _courseService = null!;

		public GetCoursesModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
			: base(mapper, scope)
		{
			_courseService = courseService;
		}

		public async Task<object> GetCoursesAsync(DataTablesAjaxRequestModel model)
		{
            var data = await _courseService.GetCoursesAsync(model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Image", "Title", "Description", "Name", "PreviewVideo" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = data.records.Select(x => new string[]
                {
                    Path.Combine("\\storage\\images", x.Image),
                    x.Title,
                    x.Description,
                    x.Category.Name,
                    x.PreviewVideo,
                    x.Id.ToString()
                })
            };
        }

    }
}
