using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.BusinessObjects
{
    public class ApplicationUser
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; } = null!;
    }
}
