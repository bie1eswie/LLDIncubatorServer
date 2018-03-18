using Safate.Incubator.API.Core.Helpers;
using Safate.Incubator.API.Core.ViewModels.Account;
using Sefate.Incubator.UserAccess.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Helpers
{
    public class UserListResponse: GenericResult
	{
		public List<RegistrationView> users { get; set; }
		public UserView user { get; set; }
    }
}
