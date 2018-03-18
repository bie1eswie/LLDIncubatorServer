using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sefate.Incubator.UserAccess.BLL;
using Safate.Incubator.API.Core.Helpers;
using Safate.Incubator.API.Core.Services;
using Safate.Incubator.API.NET.Helpers;
using Safate.Incubator.API.Core.ViewModels.Account;
using System.Web.Http.Cors;

namespace Safate.Incubator.API.NET.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class UserListController : Controller
    {
		private readonly IMembershipService _membershipService;

		public UserListController(IMembershipService membershipService)
		{
			_membershipService = membershipService;
		}
		// GET: api/Contact/GetContact
		[HttpPost("getUsers")]
		public IActionResult GetUsers([FromBody]RegistrationView user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _userListResult = null;
			try
			{
				var _users = _membershipService.GetRoleUsers(2);
				if (_users != null)
				{
					_userListResult = new UserListResponse()
					{
						Succeeded = false,
						Message = "Authentication failed",
						users = _users
					};
				}
				else
				{
					_userListResult = new UserListResponse()
					{
						Succeeded = false,
						Message = "Authentication failed"
					};
				}
			}
			catch (Exception ex)
			{
				_userListResult = new UserListResponse()
				{
					Succeeded = false,
					Message = ex.Message
				};
			}
			_result = new ObjectResult(_userListResult);
			return _result;
		}

		// GET api/Contact/GetContactByID/5
		[HttpGet("GetContactByID/{id}")]
		public IActionResult GetContactByID(int id)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _userListResult = null;
			try
			{
				var _user = _membershipService.GetUser(id);
				if (_user != null)
				{
					_userListResult = new UserListResponse()
					{
						Succeeded = false,
						Message = "",
						user = _user
					};
				}
				else
				{
					_userListResult = new UserListResponse()
					{
						Succeeded = false,
						Message = "Authentication failed"
					};
				}
			}
			catch (Exception ex)
			{
				_userListResult = new UserListResponse()
				{
					Succeeded = false,
					Message = ex.Message
				};
			}
			_result = new ObjectResult(_userListResult);
			return _result;
		}

		// POST api/Contact/PostContact
		[HttpPost("PostUser")]
		public IActionResult PostUser([FromBody]RegistrationView user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

				UserView _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, user.Fullname, user.Lastname, user.Phone, user.Fullname, new int[] { user.Role });
				if (_user != null)
				{
					var otp = _membershipService.CreateOneTimePassword();
					bool valid = _membershipService.CreateVerification(_user.Id, otp);
					if (valid)
					{
						NotificationManager.NotificationManager.SendWellcomeLetter(user.Email, user.Fullname, otp,user.Username,user.Password);
						_registrationResult = new GenericResult()
						{
							Succeeded = true,
							Message = "Registration succeeded"
						};

					}
					else
					{
						_registrationResult = new GenericResult()
						{
							Succeeded = false,
							Message = "Invalid fields."
						};
					}
				}
			}
			catch (Exception ex)
			{
				_registrationResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message
				};

			}

			_result = new ObjectResult(_registrationResult);
			return _result;
		}

		// PUT api/Contact/PutContact/5
		[HttpPut, Route("PutUser/{id}")]
		public IActionResult PutContact(int id, [FromBody] RegistrationView user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

				bool _user = _membershipService.UpdateUser(user.Username, user.Email, user.Password, user.Fullname,id,user.Phone,user.Lastname,user.Role);
				if (_user)
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = true,
						Message = "Registration succeeded"
					};

				}
				else
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Invalid fields."
					};
				}
			}
			catch (Exception ex)
			{
				_registrationResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message
				};
			}

			_result = new ObjectResult(_registrationResult);
			return _result;
		}

		// DELETE api/Contact/DeleteContactByID/5
		[HttpDelete, Route("DeleteUserByID/{id}")]
		public IActionResult DeleteContactByID(int id)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

				bool _user = _membershipService.DeleteUser(id);
				if (_user)
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = true,
						Message = "Registration succeeded"
					};
				}
				else
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Invalid fields."
					};
				}
			}
			catch (Exception ex)
			{
				_registrationResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message
				};
			}

			_result = new ObjectResult(_registrationResult);
			return _result;
		}

		[Route("getRoles")]
		[HttpGet]
		public IActionResult GetRoles()
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var requirement = _membershipService.GetRoles();

				if (requirement != null)
				{
					_result = new ObjectResult(requirement);
					return _result;
				}
				else
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = false,
						Message = "No workItems found."
					};
					_result = new ObjectResult(_requiremtsResult);
					return _result;
				}
			}
			catch (Exception ex)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
		}
	}
}