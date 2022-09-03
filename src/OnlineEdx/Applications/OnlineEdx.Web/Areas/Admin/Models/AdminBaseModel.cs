using Autofac;
using AutoMapper;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Areas.Admin.Models
{
	public abstract class AdminBaseModel : BaseModel
	{
		public AdminBaseModel()
		{

		}
		public AdminBaseModel(IMapper mapper, ILifetimeScope scope)
			: base(mapper, scope)
		{
		}
	}
}
