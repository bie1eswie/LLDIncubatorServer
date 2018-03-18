using IncubatorRequirements.DAL;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class WorkItemStage
    {
        private IncubatorRequirementsManager incubatorRequirementsManager;
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager { get; set; }

        public int StageID { get; set; }
        public string Stage { get; set; }
        public string StageCode { get; set; }
        public string NextStage { get; set; }
        public string PreviousStage { get; set; }
        public bool isActive { get; set; }
        public bool HasDocuments { get; set; }
        public List<RejectionReasonView> RejectionReasonViews { get; set; }
        public WorkItemStage()
        {
            incubatorRequirementsManager = new IncubatorRequirementsManager();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            RejectionReasonViews = new List<Views.RejectionReasonView>();
        }
        public WorkItemStage(string code, int workItem)
        {
            var getmdmStage = incubatorRequirementsManager.GetWorkItemStage(code);
            RejectionReasonViews = new List<RejectionReasonView>();
            if (getmdmStage != null)
            {
                var getDatabaseStage = incubatorWorkitemEntitiesManager.GetStageByCode(getmdmStage.Code);
                StageCode = getDatabaseStage.StageCode;
                StageID = getDatabaseStage.StageID;
                var stageMap = incubatorRequirementsManager.GetWorkItemStageByCode(StageCode);
                if (stageMap != null)
                {
                    PreviousStage = stageMap.PreviousStage_Code;
                    NextStage = stageMap.NextSage_Code;
                }
            }

            var stageReasons = incubatorRequirementsManager.WorkItemStageReasons(code);

            if (stageReasons != null)
            {
                foreach (var reason in stageReasons)
                {
                    if (reason != null)
                    {
                        this.RejectionReasonViews.Add(new RejectionReasonView(reason.Reason_Code));
                    }
                }
            }
        }

        public WorkItemStage(string name, string code, bool isActive, string hasDocuments)
        {
			incubatorRequirementsManager = new IncubatorRequirementsManager();
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			RejectionReasonViews = new List<Views.RejectionReasonView>();
			Stage = name;
            StageCode = code;
            this.isActive = isActive;
            bool hasDocs = false;
            if (!string.IsNullOrEmpty(hasDocuments))
            {
                if (Boolean.TryParse(hasDocuments, out hasDocs))
                {
                    HasDocuments = hasDocs;
                }
                else
                    HasDocuments = false;
            }
            else
            {
                HasDocuments = false;
            }
            RejectionReasonViews = new List<RejectionReasonView>();
            var stageMap = incubatorRequirementsManager.GetWorkItemStageByCode(StageCode);
            if (stageMap != null)
            {
                PreviousStage = stageMap.PreviousStage_Code;
                NextStage = stageMap.NextSage_Code;
            }
            var stageReasons = incubatorRequirementsManager.WorkItemStageReasons(StageCode);
            if (stageReasons != null)
            {
                foreach (var reason in stageReasons)
                {
                    if (reason != null)
                    {
                        this.RejectionReasonViews.Add(new RejectionReasonView(reason.Reason_Code));
                    }
                }
            }
        }
    }
}
