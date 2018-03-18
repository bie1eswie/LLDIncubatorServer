using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.Core.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Safate.Incubator.API.Core.ViewModels.Account;
using Safate.Incubator.API.Core.Services;
using System.Web.Http.Cors;

namespace Safate.Incubator.API.NET.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class ValuesController : Controller
    {

    private readonly IMembershipService _membershipService;

    public ValuesController(IMembershipService membershipService)
    {
      _membershipService = membershipService;
    }
    // GET api/values
    [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Login([FromBody] LogInView user)
    {
      IActionResult _result = new ObjectResult(false);
      GenericResult _authenticationResult = null;

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

      _result = new ObjectResult(_authenticationResult);
      return _result;
    }
  }
}
