using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.Core.Services;
using Safate.Incubator.API.Core.Helpers;
using Safate.Incubator.API.Core.ViewModels.Account;
using Sefate.Incubator.UserAccess.BLL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web.Http.Cors;
using Safate.Incubator.API.NET.Helpers;
using Safate.Incubator.API.NET.Services.Abstract;
using Safate.Incubator.API.NET.ViewModels.Account;

namespace Safate.Incubator.API.Core.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class AccountController : Controller
    {
		private readonly IMembershipService _membershipService;
		private readonly IWorkItemService _workItemService;

		public AccountController(IMembershipService membershipService, IWorkItemService workItemService)
		{
			_membershipService = membershipService;
			_workItemService = workItemService;
		}


		[HttpPost("authenticate")]
		public async Task<IActionResult> Login([FromBody] LogInView user)
		{
			IActionResult _result = new ObjectResult(false);
			LoginResult _authenticationResult = null;

			try
			{
				MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

				if (_userContext.user != null)
				{
					List<Claim> _claims = new List<Claim>();
					foreach (var role in _userContext.user.UserRoleViews)
					{
						Claim _claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Username);
						_claims.Add(_claim);
					}
					await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme)),
						new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });

					var userWorkItem = new Sefate.Incubator.WorkItem.WorkItem(_userContext.user.ClientID);
					_authenticationResult = new LoginResult()
					{
						Succeeded = true,
						Message = "Authentication succeeded",
						WorkItem =  userWorkItem,
						User = _userContext.user
					};
				}
				else
				{
					_authenticationResult = new LoginResult()
					{
						Succeeded = false,
						Message = "Authentication failed: Please ensure that your username and password are correct"
					};
				}
			}
			catch (Exception ex)
			{
				_authenticationResult = new LoginResult()
				{
					Succeeded = false,
					Message = ex.Message
				};

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}

			_result = new ObjectResult(_authenticationResult);
			return _result;
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			try
			{
				await HttpContext.Authentication.SignOutAsync("Cookies");
				return Ok();
			}
			catch (Exception ex)
			{
				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();

				return BadRequest();
			}

		}

		[Route("register")]
		[HttpPost]
		public IActionResult Register([FromBody] RegistrationView user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

					UserView _user = _membershipService.CreateUser(user.Username, user.Email, user.Password,user.Fullname,"","","", new int[] { 1 });
					if (_user != null)
					{
						var otp = _membershipService.CreateOneTimePassword();
					    bool valid = _membershipService.CreateVerification(_user.Id, otp);
						if (valid)
						{
							var workItem = _workItemService.CreateWorkIten(_user.Id, _user);
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
								Message = "Registration failed."
							};
						}
				}
				else
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Registration failed."
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

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}

			_result = new ObjectResult(_registrationResult);
			return _result;
		}

		[HttpPost("unlock")]
		public IActionResult Unlock([FromBody] ConfirmAccount user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

				var _user = _membershipService.UnlockUser(user.OneTimePassword);
				if (_user)
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = true,
						Message = "Your account has been unlocked  successfully"
					};
				}
				else
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Code not found please verify your code and try again."
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

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}

			_result = new ObjectResult(_registrationResult);
			return _result;

		}
		[HttpPost("updatePassword")]
		public IActionResult UpdatePassword([FromBody] ResetPassword resetPassword)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _registrationResult = null;

			try
			{

				var _user = _membershipService.ResetPassword(resetPassword.Email,resetPassword.NewPassword);
				if (_user)
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = true,
						Message = "Your account has been unlocked  successfully"
					};
                    NotificationManager.NotificationManager.PasswordUpdate(resetPassword.Email, "", resetPassword.NewPassword);

                }
				else
				{
					_registrationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Registration failed."
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

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}

			_result = new ObjectResult(_registrationResult);
			return _result;

		}
	}
}