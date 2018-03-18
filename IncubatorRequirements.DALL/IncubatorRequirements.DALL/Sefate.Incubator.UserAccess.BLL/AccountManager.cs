using Safate.Incubator.UserAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.UserAccess.BLL
{
	public class AccountManager
	{
		private UserAccessManager userAccessManager;

		public AccountManager()
		{
			userAccessManager = new UserAccessManager();
		}
		public UserView RegisterClient(UserView clientData)
		{
			UserView result = new UserView();
			var roleList = (from a in clientData.UserRoleViews
							select a.RoleID).ToList();
			var addClientResult = userAccessManager.CreateClient(clientData.Fullname, clientData.ClientType, clientData.Username);
			if (addClientResult > 0)
			{
				var addUser = userAccessManager.CreateUser(clientData.Username, clientData.HashedPassword, roleList, clientData.Email, clientData.Salt, clientData.Lastname, clientData.Fullname,clientData.Phone);
				result = new UserView(addUser, addClientResult);
			}
			return result;
		}

		public UserView RegisterUser(UserView clientData)
		{
			UserView result = new UserView();
			var roleList = (from a in clientData.UserRoleViews
							select a.RoleID).ToList();
			var addUser = userAccessManager.CreateUser(clientData.Username, clientData.HashedPassword, new List<int> { 2 }, clientData.Email, clientData.Salt, clientData.Lastname, clientData.Fullname, clientData.Phone);
			result = new UserView(addUser);
			return result;
		}

		public bool AuthenticateUser(ClientUserView clientData)
		{
			return userAccessManager.AuthenticateUser(clientData.Username, clientData.ClientPassword);
		}

		public bool AddUserRole(UserRoleView userRole)
		{
			return userAccessManager.AddUserRole(userRole.UserID, userRole.RoleID);
		}

		public RoleView GetRole(int roleID)
		{
			RoleView result = new RoleView();
			var role = userAccessManager.GetRole(roleID);
			result.RoleID = role.ID;
			result.Role = role.RoleText;
			return result;
		}

		public List<RoleView> GetRoles()
		{
			List<RoleView> result = new List<RoleView>();
			var roles = userAccessManager.GetRoles();
			foreach (var role in roles)
			{
				RoleView curr = new RoleView();
				curr.RoleID = role.ID;
				curr.Role = role.RoleText;
				result.Add(curr);
			}
			return result;
		}

		public List<UserRoleView> GetUserRole(int userID)
		{
			List<UserRoleView> result = new List<UserRoleView>();
			var roles = userAccessManager.GetUserRole(userID);
			foreach (var role in roles)
			{

				UserRoleView curr = new UserRoleView()
				{
					RoleID = role.RoleID.Value,
					Role = "",
					UserID = role.UserID.Value
				};
				result.Add(curr);
			}

			return result;
		}

		public UserView GetUser(int userID)
		{
			UserView userView = new UserView();
			var user = userAccessManager.GetUser(userID);
			if (user != null)
			{
				userView.Id = user.ID;
				var clientRelation = userAccessManager.GetClientRelationship(userView.Id);
				if (clientRelation != null && clientRelation.ClientID.HasValue)
					userView.ClientID = clientRelation.ClientID.Value;
				userView.Username = user.Username;
				userView.IsLocked = user.UserLocked;
				userView.Email = user.EmailAddress;
				userView.Salt = user.Salt;
				userView.HashedPassword = user.Password;
				userView.Fullname = user.Phone;
			}
			return userView;
		}

		public UserView GetUserByEmail(string email)
		{
			var user = userAccessManager.GetUserByEmail(email);
			if (user != null)
			{
				UserView userView = new UserView();
				userView.Id = user.ID;
				var clientRelation = userAccessManager.GetClientRelationship(userView.Id);
				if (clientRelation != null && clientRelation.ClientID.HasValue)
					userView.ClientID = clientRelation.ClientID.Value;
				userView.Username = user.Username;
				userView.IsLocked = user.UserLocked;
				userView.Salt = user.Salt;
				userView.HashedPassword = user.Password;
				userView.UserRoleViews = new List<UserRoleView>();
				var roles = userAccessManager.GetUserRole(userView.Id);
				foreach (var role in roles)
				{
					if (role != null)
					{
						userView.UserRoleViews.Add(new UserRoleView(role));
					}
				}
				return userView;
			}
			return null;
		}


		public UserView GetUserByUsername(string username)
		{

			var user = userAccessManager.GetUser(username);
			if (user != null)
			{
				UserView userView = new UserView();
				userView.Id = user.ID;
				var clientRelation = userAccessManager.GetClientRelationship(userView.Id);
				if (clientRelation != null && clientRelation.ClientID.HasValue)
					userView.ClientID = clientRelation.ClientID.Value;
				userView.Username = user.Username;
				userView.IsLocked = user.UserLocked;
				userView.Salt = user.Salt;
				userView.HashedPassword = user.Password;
				userView.Fullname = user.Fullname;
				userView.UserRoleViews = new List<UserRoleView>();
				var roles = userAccessManager.GetUserRole(userView.Id);
				foreach (var role in roles)
				{
					if (role != null)
					{
						userView.UserRoleViews.Add(new UserRoleView(role));
					}
				}
				return userView;
			}
			return null;
		}

		public List<UserView> GetUsersByRole(int role)
		{
			List<UserView> userViews = new List<UserView>();
			var users = userAccessManager.GetUsersByRole(role);
			foreach (var user in users)
			{
				userViews.Add(new UserView(user));
			}
			return userViews;
		}
		public bool DeleteUser(int userId)
		{
			return userAccessManager.DeleteUser(userId);

		}

		public bool UpdateUser(string username, string email, string password, string fullname, int userid, string surname, string phone, int role)
		{
			return userAccessManager.UpdateUser(username, email, password, fullname, userid, phone, surname, role);
		}
		public bool UnlockUser(string userid)
		{
			return userAccessManager.UnlockUser(userid);
		}
		public bool UpdatePassword(string newPassword, string email)
		{

			return userAccessManager.UpdatePassword(newPassword, email);
		}

		public bool CreateVerification(int userid,string number)
		{
			return userAccessManager.CreateVerification(number,userid);
		}
	}
}
