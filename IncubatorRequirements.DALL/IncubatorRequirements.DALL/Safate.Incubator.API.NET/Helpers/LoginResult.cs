using Safate.Incubator.API.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sefate.Incubator.WorkItem.Views;
using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem;

namespace Safate.Incubator.API.NET.Helpers
{
    public class LoginResult: GenericResult
	{
		public Sefate.Incubator.WorkItem.WorkItem WorkItem { get; set; }
		public UserView User { get; set; }
	}
}
