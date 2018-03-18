using Safate.Incubator.UserAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.UserAccess.BLL
{
	public class RoleView
	{
		public int RoleID { get; set; }
		public string Role { get; set; }
		private UserAccessManager userAccessManager;

		public RoleView(Role role)
		{
			userAccessManager = new UserAccessManager();
			RoleID = role.ID;
			Role = role.RoleText;
		}
		public RoleView()
		{
			userAccessManager = new UserAccessManager();
		}
		public RoleView(int id)
		{
			userAccessManager = new UserAccessManager();
			var role = userAccessManager.GetRole(id);
			RoleID = role.ID;
			Role = role.RoleText;
		}
	}
}
