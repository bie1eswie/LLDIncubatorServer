
using Sefate.Incubator.UserAccess.BLL;
using System.Security.Principal;
using Sefate.Incubator.WorkItem.Views;

namespace Safate.Incubator.API.Core.Services
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public UserView user { get; set; }
		public WorkItemView WorkItem { get; set; }

		public bool IsValid()
        {
            return Principal != null;
        }
    }
}
