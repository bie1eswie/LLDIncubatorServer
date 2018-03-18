using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public class WorkItemDocumentStatusInfor
    {
        public int StatusID { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

		public WorkItemDocumentStatusInfor(DAL.WorkItemStage workItemStatu)
        {
            this.StatusID = workItemStatu.WorkItemStageID;
            this.StatusCode = workItemStatu.StageID.ToString();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

        }

        public WorkItemDocumentStatusInfor()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }
        public WorkItemDocumentStatusInfor(int id)
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

            var dbStatus = incubatorWorkitemEntitiesManager.GetWorkItemDocumentStatus(id);
            if (dbStatus != null)
                this.StatusCode = dbStatus.StatusID.ToString();
            else
            {
                this.StatusCode = "0";
            }
        }
    }
}
