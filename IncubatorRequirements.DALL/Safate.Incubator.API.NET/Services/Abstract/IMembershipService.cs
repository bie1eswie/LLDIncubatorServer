
using Safate.Incubator.API.Core.ViewModels;
using Safate.Incubator.API.Core.ViewModels.Account;
using Sefate.Incubator.UserAccess.BLL;
using System.Collections.Generic;

namespace Safate.Incubator.API.Core.Services
{
    public interface IMembershipService
    {
		MembershipContext ValidateUser(string username, string password);
		UserView CreateUser(string username, string email, string password, string fullname, string lastname, string phone,string firstname, int[] roles);
		UserView GetUser(int userId);
        List<UserRoleView> GetUserRoles(string username);
		List<RegistrationView> GetRoleUsers(int role);
		bool UpdateUser(string username, string email, string password, string fullname, int userid,string phone,string surname,int role);
		bool DeleteUser(int userId);
		List<RoleView> GetRoles();
		bool UnlockUser(string user);
		bool ResetPassword(string email, string password);
		string CreateOneTimePassword();
		bool CreateVerification(int userID, string number);
	}
}
