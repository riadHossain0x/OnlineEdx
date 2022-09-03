using OnlineEdx.Web.Enums;

namespace OnlineEdx.Web.Models
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}
