using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.Core.ViewModels.Account
{
    public class RegistrationView
    {
		[Required]
		public string Fullname { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
