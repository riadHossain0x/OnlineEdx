using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class GetCategoriesModel : AdminBaseModel
    {
        private readonly ICategoryService _categoryService = null!;

        public GetCategoriesModel()
        {

        }

        public GetCategoriesModel(IMapper mapper, ILifetimeScope scope, ICategoryService categoryService)
            : base(mapper, scope)
        {
            _categoryService = categoryService;
        }

        internal async Task<object> GetCategoriesAsync(DataTablesAjaxRequestModel model)
        {
            var data = await _categoryService.GetCategorisAsync(model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Image", "Name", "Description" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = data.records.Select(x => new string[]
                {
                    x.Image,
                    x.Name,
                    x.Description,
                    x.Id.ToString()
                })
            };
        }
    }
}
