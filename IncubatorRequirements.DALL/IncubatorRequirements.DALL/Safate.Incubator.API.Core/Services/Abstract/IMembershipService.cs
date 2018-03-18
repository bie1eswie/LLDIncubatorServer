
using Safate.Incubator.API.Core.ViewModels;
using Sefate.Incubator.UserAccess.BLL;
using System.Collections.Generic;

namespace Safate.Incubator.API.Core.Services
{
    public interface IMembershipService
    {
        bool ValidateUser(string username, string password);
        bool CreateUser(string username, string email, string password, int[] roles);
		UserView GetUser(int userId);
        List<UserRoleView> GetUserRoles(string username);
    }
}
