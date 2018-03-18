using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.Core.ViewModels.Account
{
    public class LogInView
    {
		public string Username { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
