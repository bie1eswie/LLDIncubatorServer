
using Safate.Incubator.API.Core.Services;
using Safate.Incubator.API.Core.ViewModels.Account;
using Safate.Incubator.API.NET.Services.Abstract;
using Sefate.Incubator.UserAccess.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace PhotoGallery.Infrastructure.Services
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IEncryptionService _encryptionService;
		private readonly IWorkItemService _workItemService;
		private AccountManager accountManager;
		#endregion
		public MembershipService(IEncryptionService encryptionService, IWorkItemService workItemService)
        {
            _encryptionService = encryptionService;
			accountManager = new AccountManager();
			_workItemService = workItemService;
		}

		#region IMembershipService Implementation

		public MembershipContext ValidateUser(string username, string password)
		{
			var membershipCtx = new MembershipContext();

			var user = accountManager.GetUserByUsername(username);
			if (user != null && isUserValid(user, password))
			{
				//var userRoles = GetUserRoles(user.Username);
				membershipCtx.user = user;
				var identity = new GenericIdentity(user.Username);
				membershipCtx.Principal = new GenericPrincipal(
					identity,
					user.UserRoleViews.Select(x => x.Role).ToArray());
				membershipCtx.WorkItem = _workItemService.GetWorkIten(user.ClientID);
			}
			return membershipCtx;
		}
		public UserView CreateUser(string username, string email, string password,string fullname,string lastname,string phone,string firstname, int[] roles)
        {
            var existingUser = accountManager.GetUserByUsername(username);

			if (existingUser != null)
			{
				throw new Exception("Username is already in use");
			}
			else
			{
				var existingUserEmail = accountManager.GetUserByEmail(email);
				if (existingUserEmail != null)
				{
					throw new Exception("Username is already in use");
				}
			}

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new UserView()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = true,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                DateCreated = DateTime.Now,
                ClientType =1,
				Lastname = lastname,
				Phone =phone,
				Fullname = firstname
			};
			var currRole = roles.FirstOrDefault();

			if (currRole == 1)
			{
				if (string.IsNullOrEmpty(user.Fullname))
				{
					user.Fullname = fullname;
				}
				user.UserRoleViews = new List<UserRoleView>();
				user.UserRoleViews.Add(new UserRoleView() { RoleID = 1 });
				user = accountManager.RegisterClient(user);

			}
			else
			{
				user = accountManager.RegisterUser(user);
			}
			if (roles != null || roles.Length > 0)
			{
				foreach (var role in roles)
				{
					user.UserRoleViews.Add(new UserRoleView()
					{
						UserID = user.Id,
						RoleID = role
					});
				}
			}

			return user;
        }

        public UserView GetUser(int userId)
        {
            return accountManager.GetUser(userId);
        }

        public List<UserRoleView> GetUserRoles(string username)
        {
            List<UserRoleView> _result = new List<UserRoleView>();

            var existingUser = accountManager.GetUserByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoleViews)
                {
                    _result.Add(userRole);
                }
            }

            return _result.Distinct().ToList();
        }
        #endregion

        #region Helper methods
        private void addUserToRole(int user, int roleId)
        {
            var role = accountManager.GetRole(roleId);
            if (role == null)
                throw new Exception("Role doesn't exist.");

            var userRole = new UserRoleView()
            {
                RoleID= role.RoleID,
                UserID = user
            };
        }

        private bool isPasswordValid(UserView user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool isUserValid(UserView user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked.Value;
            }

            return false;
        }

		public List<RegistrationView> GetRoleUsers(int role)
		{
			List<RegistrationView> result = new List<RegistrationView>();
			var users = accountManager.GetUsersByRole(role);
			foreach (var user in users)
			{
				result.Add(new RegistrationView(user));
			}
			return result;
		}

		public bool DeleteUser(int userId)
		{
			return accountManager.DeleteUser(userId);
		}

		public bool UpdateUser(string username, string email, string password, string fullname, int userid, string phone, string surname,int role)
		{
			return accountManager.UpdateUser(username, email, password, fullname, userid,surname,phone,role);
		}

		public List<RoleView> GetRoles()
		{
			return accountManager.GetRoles();
		}
		public bool UnlockUser(string user)
		{
			return accountManager.UnlockUser(user);
		}

		public bool ResetPassword(string email,string password)
		{
			var user = accountManager.GetUserByEmail(email);
			password = _encryptionService.EncryptPassword(password, user.Salt);
			return accountManager.UpdatePassword(password, email);
		}

		public string CreateOneTimePassword()
		{
			return _encryptionService.CreateSalt().Substring(0, 5);
		}

		public bool CreateVerification(int userID, string number)
		{
			return accountManager.CreateVerification(userID, number);
		}
		#endregion
	}
}
