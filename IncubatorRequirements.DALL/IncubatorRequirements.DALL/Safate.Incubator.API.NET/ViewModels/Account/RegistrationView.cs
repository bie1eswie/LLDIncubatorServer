using Sefate.Incubator.UserAccess.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.Core.ViewModels.Account
{
	public class RegistrationView
	{
		[Required]
		public string Fullname { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
		public int Role { get; set; }
		public int Id { get; set; }
		public RegistrationView(UserView user)
		{
			Fullname = user.Fullname;
			Username = user.Username;
			Lastname = user.Lastname;
			Phone = user.Phone;
			Email = user.Email;
			Id = user.Id;
			if(user.UserRoleViews!=null)
				Role = user.UserRoleViews.FirstOrDefault().RoleID;
		}
		public RegistrationView()
		{

		}
	}
}
	
