using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Incubation
{
    public class WorkItemIncubationStageInfor
    {
        public int StatusID { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool isDirty { get; set; }
        public bool isNew { get; set; }
        public int ID { get; set; }
        public int WorkItem { get; set; }
        public int User { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

        public WorkItemIncubationStageInfor()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }
        public WorkItemIncubationStageInfor(DAL.WorkItemIncubationStage workItemIncubationStage)
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            if (workItemIncubationStage.IncubationSageID.HasValue)
            StatusID = workItemIncubationStage.IncubationSageID.Value;
            var stage = incubatorWorkitemEntitiesManager.GetWorkItemIncubationStage(StatusID);
            Status = stage.IncubationStageText;
            ModifiedDate = workItemIncubationStage.ModifiedDate.Value;
        }

        public bool UpdateSelf()
        {
            bool result = false;
            if (incubatorWorkitemEntitiesManager == null)
                incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            if (isDirty)
                return incubatorWorkitemEntitiesManager.UpdateWorkItemIncubationStage(ID,StatusID,WorkItem, User);
            else if (isNew)
            {
                return incubatorWorkitemEntitiesManager.AddWorkItemIncubationStage(WorkItem, 9, User);
            }
            return result;
        }
    }
}
