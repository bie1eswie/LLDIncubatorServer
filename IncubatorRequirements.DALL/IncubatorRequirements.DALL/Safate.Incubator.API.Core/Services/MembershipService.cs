
using Safate.Incubator.API.Core.Services;
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
		private AccountManager accountManager;
		#endregion
		public MembershipService(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
			accountManager = new AccountManager();

		}

        #region IMembershipService Implementation

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return membershipCtx;
        }
        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new User()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                DateCreated = DateTime.Now
            };

            _userRepository.Add(user);

            _userRepository.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            _userRepository.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    _result.Add(userRole.Role);
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

        private bool isPasswordValid(string user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, ""), password);
        }

        private bool isUserValid(string user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
        #endregion
    }
}
