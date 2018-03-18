using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Incubation
{
    public class WorkItemTimeLine
    {
        public int TimelineID { get; set; }
        public int WorkItemID { get; set; }
        public int WorkItemStageID { get; set; }
        public string WorkItemStage { get; set; }
        public string CreateDate { get; set; }
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        public string CreatedUser { get; set; }
        public WorkItemTimeLine(DAL.WorkItemTimeLine WorkItemTimeLine)
        {
            TimelineID = WorkItemTimeLine.ID;
            WorkItemID = WorkItemTimeLine.WorkItemID.Value;
            WorkItemStageID = WorkItemTimeLine.WorkItemStageID;
            CreateDate = WorkItemTimeLine.CreatedDate.Value.ToString("yyyy-M-d HH:mm:ss");
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            var status = incubatorWorkitemEntitiesManager.GetItemStage(WorkItemStageID);
            if (status == null)
            {
                var incubation = incubatorWorkitemEntitiesManager.GetWorkItemIncubationStage(WorkItemStageID);
                if(incubation!=null)
                {
                    WorkItemStage = incubation.IncubationStageText;
                }
            }
            else
            {
                WorkItemStage = status.StageText;
            }
            if (WorkItemTimeLine.CreatedBy.HasValue)
            {
                var user = new UserView(WorkItemTimeLine.CreatedBy.Value);
                CreatedUser = user.Fullname==null? user.Username: user.Fullname;
            }
        }
        public WorkItemTimeLine()
        {

        }
    }
}
