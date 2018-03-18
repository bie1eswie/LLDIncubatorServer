using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.UserAccess.BLL
{
    public class ClientUserView
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public int ClientType { get; set; }
        public string Username { get; set; }
        public List<UserRoleView> ClientRoles { get; set; }
    }
}
