using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class DashboardModel : AdminBaseModel
    {
        public Guid CourseId { get; set; }
        private readonly IEnrollmentService _enrollmentService = null!;

        public DashboardModel()
        {

        }

        public DashboardModel(IMapper mapper, ILifetimeScope scope, IEnrollmentService enrollmentService)
            : base(mapper, scope)
        {
            _enrollmentService = enrollmentService;
        }

        public async Task<object> GetEnrolledUsers(DataTablesAjaxRequestModel model)
        {
            var data = await _enrollmentService.GetEnrolledUsersAsync(model.PageIndex, model.PageSize, 
                model.SearchText, null!);

            return new
            {
                recordsTotal = data.total,
                recordsFilterd = data.totalDisplay,
                data = data.records.Select(x => new string[]
                {
                    x.FirstName,
                    x.LastName,
                    x.Email,
                    x.CourseTitle,
                    x.CourseCategory,
                    x.ApplicationUserId.ToString()
                })
            };
        }
    }
}
