using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.CompanyProfile;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Requrements.BLL;
using Sefate.Incubator.WorkItem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem
{
    public enum WorkItemStatus
    {
        Created = 1,
        Submitted = 2,
        PendingReview = 3,
        Reviewed = 4,
        Accepted = 5,
    }
    public class WorkItem
    {
        public int WorkItemID { get; set; }
        public Guid WorkItemReference { get; set; }
        public string Status { get; set; }
        public List<WorkItemDocument> WorkItemDocuments { get; set; }
        public Client PrimaryClient { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public WorkItemStatusInfor WorkItemStatusInfor { get; set; }
        public string CurrentUserRole { get; set; }
		public bool IsChecked { get; set; }
        public UserView CreatedBy { get; set; }
        public List<Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine> WorkItemTimeLine { get; set; }
        public List<Sefate.Incubator.WorkItem.Incubation.WorkItemIncubatorComments> WorkItemIncubationComment { get; set; }
        public ClientProfile ClientProfile { get; set; }
        public RequirementsBuilder.WorkItemStage WorkItemStage { get; set; }
        private RequirementManager requirementManager;
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        public WorkItem()
        {
            requirementManager = new Requrements.BLL.RequirementManager();
            WorkItemDocuments = new List<Incubator.WorkItem.WorkItemDocument>();
            PrimaryClient = new Client();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            WorkItemStatusInfor = new RequirementsBuilder.WorkItemStatusInfor();
            WorkItemTimeLine = new List<Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine>();
            WorkItemIncubationComment = new List<Sefate.Incubator.WorkItem.Incubation.WorkItemIncubatorComments>();
        }

        public bool CreateWorkItem(string registrationNo)
        {
            requirementManager = new Requrements.BLL.RequirementManager();
            var client = incubatorWorkitemEntitiesManager.GetClientByRegNo(registrationNo);
            PrimaryClient = new Client(client.ClientName, registrationNo, client.ClientTypeID);
            var workItem = incubatorWorkitemEntitiesManager.CreateWorkItem(Constants.CreatedStatusID, client.ClientID, client.ClientID);
            WorkItemID = workItem;
            return workItem > 0;
        }

        public WorkItemRequirements GetWorkItemRequirements()
        {
            List<DAL.WorkItemField> workItemDataFields = new List<DAL.WorkItemField>();
            var workItemData = incubatorWorkitemEntitiesManager.GetWorkItemFields(WorkItemID);
            if (workItemData != null)
            {
                workItemDataFields = workItemData.ToList();
            }
            WorkItemRequirements result = new WorkItemRequirements(PrimaryClient.ClientTypeInfor.ClientTypeCode, WorkItemStatusInfor.StatusCode, workItemDataFields, CurrentUserRole, WorkItemID);
            return result;
        }

        public WorkItem(int clientID)
        {
            requirementManager = new Requrements.BLL.RequirementManager();
            this.WorkItemTimeLine = new List<Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine>();
            this.WorkItemIncubationComment = new List<Incubation.WorkItemIncubatorComments>();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            WorkItemDocuments = new List<WorkItemDocument>();
            var dbItem = incubatorWorkitemEntitiesManager.GetWorkItemByClient(clientID);
            if (dbItem != null)
            {
                SetProperties(dbItem);
            }
        }

		public WorkItem(int clientID, bool clientId = false)
        {
			requirementManager = new Requrements.BLL.RequirementManager();
			this.WorkItemTimeLine = new List<Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine>();
            this.WorkItemIncubationComment = new List<Incubation.WorkItemIncubatorComments>();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            WorkItemDocuments = new List<WorkItemDocument>();
            var dbItem = incubatorWorkitemEntitiesManager.GetWorkItemByClient(clientID);
            if (dbItem != null)
            {
                SetProperties(dbItem);
            }
        }

		public WorkItem(int workitem, int client)
		{
			requirementManager = new Requrements.BLL.RequirementManager();
			this.WorkItemTimeLine = new List<Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine>();
			this.WorkItemIncubationComment = new List<Incubation.WorkItemIncubatorComments>();
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			WorkItemDocuments = new List<WorkItemDocument>();
			var dbItem = incubatorWorkitemEntitiesManager.GetWorkItemByID(workitem);
			if (dbItem != null)
			{
				SetProperties(dbItem);
			}
		}

		public void SetProperties(DAL.WorkItem workItem)
        {
            this.WorkItemID = workItem.ID;
			if(workItem.IsChecked.HasValue)
			IsChecked = workItem.IsChecked.Value;	

			this.CreatedDate = workItem.CreatedDate.Value.ToString("yyyy-M-d");
            if (workItem.ModifiedDate.HasValue)
                ModifiedDate = workItem.ModifiedDate.Value.ToString("yyyy-M-d");
            if (workItem.StatusID.HasValue)
            {
                var dbStatus = incubatorWorkitemEntitiesManager.GetWorkItemStatus(workItem.ID);
				if (dbStatus != null)
				{
					this.WorkItemStatusInfor = new WorkItemStatusInfor(dbStatus);
					this.Status = WorkItemStatusInfor.Status;
				}
            }
            if (workItem.ClientID.HasValue)
            {
                var dbClient = incubatorWorkitemEntitiesManager.GetClientByID(workItem.ClientID.Value);
                if (dbClient != null)
                    this.PrimaryClient = new Client(dbClient);
            }
            if (!string.IsNullOrEmpty(workItem.CreatedBy))
            {
                int user = 0;
                if (Int32.TryParse(workItem.CreatedBy, out user))
                {
                    CreatedBy = new UserView(user);
                }
            }

            var timeline = incubatorWorkitemEntitiesManager.GetWorkItemTimeLine(workItem.ID);
            if (timeline != null)
            {
                foreach (var item in timeline)
                {
                    WorkItemTimeLine.Add(new Sefate.Incubator.WorkItem.Incubation.WorkItemTimeLine(item));
                }
            }

            var itemComments = incubatorWorkitemEntitiesManager.GetWorkItemComments(workItem.ID);
            if (itemComments != null)
            {
                foreach (var item in itemComments)
                {
                    WorkItemIncubationComment.Add(new Incubation.WorkItemIncubatorComments(item));
                }
            }

            var itemDocuments = incubatorWorkitemEntitiesManager.GetWorkItemDocumet(this.WorkItemID);

            if (itemDocuments != null)
            {
                foreach (var item in itemDocuments)
                {
                    var field = requirementManager.GetField(item.FieldMapCode, WorkItemID);
					if (field != null)
					{
						var document = new WorkItemDocument(item);
						document.DocumentType = field.FieldName;
						this.WorkItemDocuments.Add(document);
					}
                }
            }
            ClientProfile = new CompanyProfile.ClientProfile(WorkItemID);
        }
    }
}
