using Microsoft.AspNetCore.Http;

namespace OnlineEdx.Infrastructure.Services
{
	public interface IFileService
	{
        Task<string> StoreFileAsync(IFormFile file);
    }
}
