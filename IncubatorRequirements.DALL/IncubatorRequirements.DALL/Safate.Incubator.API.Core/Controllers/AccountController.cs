using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.Core.Services;
using Safate.Incubator.API.Core.Helpers;
using Safate.Incubator.API.Core.ViewModels.Account;

namespace Safate.Incubator.API.Core.Controllers
{
    [Produces("application/json")]
	[Route("api/[controller]")]
	public class AccountController : Controller
    {
		private readonly IMembershipService _membershipService;

		public AccountController(IMembershipService membershipService)
		{
			_membershipService = membershipService;
		}


		[HttpPost("authenticate")]
		public IActionResult Login([FromBody] LogInView user)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _authenticationResult = null;

			try
			{
				bool _userContext = _membershipService.ValidateUser(user.Username, user.Password);

				if (_userContext)
				{
					//IEnumerable<Role> _roles = _userRepository.GetUserRoles(user.Username);
					//List<Claim> _claims = new List<Claim>();
					//foreach (Role role in _roles)
					//{
					//	Claim _claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Username);
					//	_claims.Add(_claim);
					//}
					//await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					//	new ClaimsPrincipal(new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme)),
					//	new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });


					_authenticationResult = new GenericResult()
					{
						Succeeded = true,
						Message = "Authentication succeeded"
					};
				}
				else
				{
					_authenticationResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Authentication failed"
					};
				}
			}
			catch (Exception ex)
			{
				_authenticationResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message
				};

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}
			return Ok(_authenticationResult);
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
				if (ModelState.IsValid)
				{
					bool _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

					if (_user)
					{
						_registrationResult = new GenericResult()
						{
							Succeeded = true,
							Message = "Registration succeeded"
						};
					}
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

				//_loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
				//_loggingRepository.Commit();
			}

			_result = new ObjectResult(_registrationResult);
			return _result;
		}
	}
}