using Safate.Incubator.UserAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.UserAccess.BLL
{
    enum UserType
    {
        ClientCompanyUser = 1,
        EvaluatorUser = 2
    }
    public class UserRoleView
    {
        public string Role { get; set; }
        public int RoleID { get; set; }
		public int UserID { get; set; }

		public UserRoleView(UserRole userRole)
		{
			RoleID = userRole.RoleID.Value;
			UserID = userRole.UserID.Value;
			var role = new RoleView(RoleID);
			Role = role.Role;
		}

		public UserRoleView()
		{
		}
	}
}
