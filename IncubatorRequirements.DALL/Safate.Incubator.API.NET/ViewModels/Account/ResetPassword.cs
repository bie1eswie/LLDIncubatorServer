using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.ViewModels.Account
{
    public class ResetPassword
    {
		public string NewPassword { get; set; }
		public string Email { get; set; }
		public string ConfirmPassword { get; set; }
		public ResetPassword()
		{
		}
	}
}
