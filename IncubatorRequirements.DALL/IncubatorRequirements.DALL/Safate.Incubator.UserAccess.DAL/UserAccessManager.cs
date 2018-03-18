using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safate.Incubator.UserAccess.DAL
{
    public class UserAccessManager
    {
		public static IncubatorClientsEntities Get<T>(bool noChangeTracking = false)
		{
			var t = Activator.CreateInstance(typeof(T), "data source=localhost;initial catalog=IncubatorClients;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

			var dbContext = t as DbContext;
			if (t != null)
			{
				var timeoutValue = "60";
				int timeout = 0;
				if (!int.TryParse(timeoutValue, out timeout))
				{
					timeout = 60;
				}

				// Set the SQL command timeout to the configured timeout value;
				dbContext.Database.CommandTimeout = timeout;

				if (noChangeTracking)
				{
					dbContext.Configuration.AutoDetectChangesEnabled = false;
				}
			}

			return t as IncubatorClientsEntities;
		}


		#region Client
		public int CreateClient(string clientName, int clientType, string registrationNo)
        {
            int result = 0;
            using (var userContext = Get<IncubatorClientsEntities>())
            {
                var client = new Client()
                {
                    ClientName = clientName,
                    ClientTypeID = clientType,
                    CreatedDate = DateTime.Now,
                    RegistrationNumber = registrationNo
                };
                userContext.Clients.Add(client);
                userContext.SaveChanges();
                result = client.ClientID;
            }
            return result;
        }
        #endregion
        #region User 
        public User CreateUser(string username, string password, List<int> userRoles, string email,string salt,string lastname, string firstname, string phone)
        {
			var user = new User();

			using (var userContext = Get<IncubatorClientsEntities>())
            {
                user = new User()
                {
                    EmailAddress = email,
                    Password = password,
                    Username = username,
					Salt =salt,
					DateCreated =DateTime.Now,
					UserLocked =true,
					Surname = lastname,
					Phone =phone,
					Fullname = firstname
                };
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
            using (var userContext = Get<IncubatorClientsEntities>())
            {
                foreach (var role in userRoles)
                {
                    var userRole = new UserRole()
                    {
                        RoleID = role,
                        UserID = user.ID,
                    };

                    userContext.UserRoles.Add(userRole);
                }
                userContext.SaveChanges();
            }
			return user;
        }

		public bool CreateVerification(string number,int user)
		{
			bool result = false;
			using (var userContext = Get<IncubatorClientsEntities>())
			{
				var userRole = new VarificationNumber()
				{
					UserID = user,
					Number = number,
				};
				userContext.VarificationNumbers.Add(userRole);
			  result =	userContext.SaveChanges()>0;
			}
			return result;
		}

        public bool AuthenticateUser(string username,string password)
        {
            bool result = false;
            using (var userContext = Get<IncubatorClientsEntities>())
            {
                var user = from a in userContext.Users
                           where a.Password == password && a.Username == username
                           select a;

                result = user != null && user.Any();
            }
            return result;
        }

		public User GetUser(int userID)
		{
			using (var userContext = Get<IncubatorClientsEntities>())
			{
				var user = from a in userContext.Users
						   where a.ID == userID
						   select a;

				return user.FirstOrDefault();
			}
		}

		public User GetUserByEmail(string email)
		{
			using (var userContext = Get<IncubatorClientsEntities>())
			{
				var user = from a in userContext.Users
						   where a.EmailAddress == email
						   select a;

				return user.FirstOrDefault();
			}
		}

		public User GetUser(string username)
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				IEnumerable<User> user = from a in currentContext.Users
						   where a.Username == username
						   select a;

				if (user != null && user.Any())
					return user.FirstOrDefault();
				else return null;
			}
		}
		public CompanyUser GetClientRelationship(int userID)
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				IEnumerable<CompanyUser> user = from a in currentContext.CompanyUsers
												where a.UserID == userID
													   select a;

				if (user != null && user.Any())
					return user.FirstOrDefault();
				else return null;
			}
		}

		public CompanyUser GetClientRelationships(int clientID)
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				IEnumerable<CompanyUser> user = from a in currentContext.CompanyUsers
												where a.ClientID == clientID
													   select a;

				if (user != null && user.Any())
					return user.FirstOrDefault();
				else return null;
			}
		}
		#endregion

		#region User Access Roles
		public Role GetRole(int role)
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var roleList = from a in currentContext.Roles
							   where a.ID == role
							   select a;
				return roleList.FirstOrDefault();
			}
		}

		public List<Role> GetRoles()
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var roleList = from a in currentContext.Roles
							   select a;
				if (roleList != null)
					return roleList.ToList();
				else return null;
			}
		}

		public List<UserRole> GetUserRole(int user)
		{
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var roleList = from a in currentContext.UserRoles
							   where a.UserID == user
							   select a;
				if (roleList != null)
					return roleList.ToList();
				else return null;
			}
		}

        public List<UserRole> GetUserRoleByRole(int role)
        {
            using (var currentContext = Get<IncubatorClientsEntities>())
            {
                var roleList = from a in currentContext.UserRoles
                               where a.RoleID == role
                               select a;
				if (roleList != null)
					return roleList.ToList();
				else return null;
            }
        }

        public bool AddUserRole(int user, int role)
		{
			bool result = false;
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var userRole = new UserRole()
				{ 
					 RoleID = role,
					 UserID = user
				};
				currentContext.UserRoles.Add(userRole);
				currentContext.SaveChanges();
				result = userRole.ID > 0;
			}
			return result;
		}
        public List<User> GetUsersByRole(int role)
        {
            List<User> result = new List<User>();
            var userRoles = GetUserRoleByRole(role);
            if(userRoles!=null&& userRoles.Any())
            {
                foreach(var ur in userRoles)
                {
                    if(ur.UserID.HasValue)
                    {
                        var user = GetUser(ur.UserID.Value);
                        result.Add(user);
                    }
                }
            }
            return result;
        }

        public bool UpdateUser(string username, string email, string password, string fullname, int userid, string phone, string surname,int role)
		{
            bool result = false;
            using (var currentContext = Get<IncubatorClientsEntities>())
            {
                var roleList = from a in currentContext.Users
                               where a.ID == userid
                               select a;
                foreach(var user in roleList)
                {
                    user.Password = password;
                    user.Username = username;
                    user.EmailAddress = email;
					user.Fullname = fullname;
					user.Surname = surname;
					user.Phone = phone;
                }
                result = currentContext.SaveChanges() > 0;
            }

			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var roleList = from a in currentContext.UserRoles
							   where a.ID == userid
							   select a;
				foreach (var user in roleList)
				{
					user.RoleID = role;
				}
				result = currentContext.SaveChanges() > 0;
			}
			return result;
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;
            using (var currentContext = Get<IncubatorClientsEntities>())
            {
                var roleList = from a in currentContext.Users
                               where a.ID == userId
                               select a;
                if(roleList!=null)
                {
                    var user = roleList.FirstOrDefault();
                    currentContext.Users.Remove(user);
                }
                result = currentContext.SaveChanges() > 0;
            }
            return result;
        }
		public bool UnlockUser(string verification)
		{
			bool result = false;
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var roleList = from a in currentContext.VarificationNumbers
							   where a.Number == verification
							   select a;
				if (roleList != null && roleList.Any())
				{
					var user = roleList.FirstOrDefault();

					var userList = from a in currentContext.Users
								   where a.ID == user.UserID
								   select a;

					foreach (var userobj in userList)
					{
						userobj.UserLocked = false;
					}
				}
				result = currentContext.SaveChanges() > 0;
			}
			return result;
		}

		public bool UpdatePassword(string newPassword, string email)
		{
			bool result = false;
			using (var currentContext = Get<IncubatorClientsEntities>())
			{
				var userList = from a in currentContext.Users
							   where a.EmailAddress == email
							   select a;

				foreach (var userobj in userList)
				{
					userobj.Password = newPassword;
				}
				result = currentContext.SaveChanges() > 0;
			}
			return result;
		}
        #endregion
    }
	
}
