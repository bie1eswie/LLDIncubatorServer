using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class WorkItemStatusInfor
    {
        public int StatusID { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }

		private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

		public WorkItemStatusInfor(DAL.WorkItemStage workItemStatu)
        {
            this.StatusID = workItemStatu.StageID.Value;
            this.StatusCode = workItemStatu.StageID.ToString();
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			var stage = incubatorWorkitemEntitiesManager.GetItemStage(workItemStatu.StageID.Value);
			if (stage != null)
				this.Status = stage.StageText;

		}

        public WorkItemStatusInfor()
        {
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
		}
		public WorkItemStatusInfor(int id)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

			var dbStatus = incubatorWorkitemEntitiesManager.GetWorkItemStatus(id);
			if (dbStatus != null)
            {
                this.StatusCode = dbStatus.StageID.ToString();
                var stage = incubatorWorkitemEntitiesManager.GetItemStage(dbStatus.StageID.Value);
                if (stage != null)
                    this.Status = stage.StageText;
            }
			else
			{
              bool result =  incubatorWorkitemEntitiesManager.AddItemStage(id);
				this.Status = "1";

			}
		}
	}
}
