using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sefate.Incubator.WorkItem.Utilities;
using Sefate.Incubator.WorkItem.Requrements.BLL;

namespace Sefate.Incubator.WorkItem.CompanyProfile
{
   public class ClientProfile
    {
        public string Sector { get; set; }
        public  string ContactPerson { get; set; }
        public  string Contacts { get; set; }
        public string Website { get; set; }
        private RequirementManager requirementManager;
        public ClientProfile()
        {
            requirementManager = new Requrements.BLL.RequirementManager();
        }

        public ClientProfile(int workitem)
        {
            requirementManager = new Requrements.BLL.RequirementManager();
            var contactMethod = requirementManager.GetFieldValue(Constants.ContactPersonMethodCode, workitem);
            string method = string.Empty;
            if (contactMethod != null)
            {
                method = contactMethod;
            }
            var contactPerson = requirementManager.GetFieldValue(Constants.ContactPersonMapCode, workitem);

            if (contactPerson != null)
            {
                ContactPerson = contactPerson;
            }
            var email = requirementManager.GetFieldValue(Constants.EmailMapCode, workitem);

            if (email != null)
            {
                if(method =="Email")
                this.Contacts = email;
            }
            var cell = requirementManager.GetFieldValue(Constants.CellMapCode, workitem);

            if (cell != null)
            {
                if(method == "Cell Phone")
                this.Contacts = cell;
            }
            var sector = requirementManager.GetFieldValue(Constants.SectorMapCode, workitem);

            if (sector != null)
            {
                this.Sector = sector;
            }

            var web = requirementManager.GetFieldValue(Constants.WebsiteMapCode, workitem);

            if (web != null)
            {
                this.Website = web;
            }
        }
    }
}
