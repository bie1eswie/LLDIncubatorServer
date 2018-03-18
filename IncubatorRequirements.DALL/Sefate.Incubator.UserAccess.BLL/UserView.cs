using Safate.Incubator.UserAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.UserAccess.BLL
{
	public class UserView
	{
        private AccountManager accountManager;
        public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string HashedPassword { get; set; }
		public string Salt { get; set; }
		public bool? IsLocked { get; set; }
		public DateTime? DateCreated { get; set; }
		public string Fullname { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public List<UserRoleView> UserRoleViews { get; set; }
		public int ClientType { get; set; }
        public int ClientID { get; set; }

		public UserView()
		{
			UserRoleViews = new List<UserRoleView>();
            accountManager = new BLL.AccountManager();
        }

		public UserView(User user,int? clientID = null)
		{
			Id = user.ID;
			Username = user.Username;
			Email = user.EmailAddress;
			Salt = user.Salt;
			IsLocked = user.UserLocked;
			DateCreated = user.DateCreated;
            accountManager = new AccountManager();
			if(clientID!=null)
			ClientID = clientID.Value;
			Lastname = user.Surname;
			Phone = user.Phone;
			Fullname = user.Fullname;
            UserRoleViews = new List<UserRoleView>();
			UserRoleViews.AddRange(accountManager.GetUserRole(Id));
		}

		public UserView(int id)
		{
			accountManager = new AccountManager();
			var user = accountManager.GetUser(id);
			Id = user.Id;
			Username = user.Username;
			Email = user.Email;
			Salt = user.Salt;
			IsLocked = user.IsLocked;
			DateCreated = user.DateCreated;
			Lastname = user.Lastname;
			Phone = user.Phone;
			Fullname = user.Fullname;
			UserRoleViews = new List<UserRoleView>();
			UserRoleViews.AddRange(accountManager.GetUserRole(Id));
		}
	}
}
