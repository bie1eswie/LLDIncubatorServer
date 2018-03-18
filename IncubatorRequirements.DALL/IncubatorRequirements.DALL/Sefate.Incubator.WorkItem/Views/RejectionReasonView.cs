using IncubatorRequirements.DAL;
using IncubatorRequirements.DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Views
{
   public class RejectionReasonView
    {
        public string Code { get; set; }
        public string Description { get; set; }
        private IncubatorRequirementsManager incubatorRequirementsManager;

        public RejectionReasonView()
        {
            incubatorRequirementsManager = new IncubatorRequirementsManager();
        }
        public RejectionReasonView(string code)
        {
            incubatorRequirementsManager = new IncubatorRequirementsManager();

            var reason = incubatorRequirementsManager.RejectionReason(code);
            if(reason!=null)
            {
                Code = reason.Code;
                Description = reason.Name;
            }
        }

        public RejectionReasonView(RejectionReason reason)
        {
            incubatorRequirementsManager = new IncubatorRequirementsManager();
            if (reason != null)
            {
                Code = reason.Code;
                Description = reason.Description;
            }
        }
    }
}
