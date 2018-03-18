using Safate.Incubator.API.NET.Services.Abstract;
using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Requrements.BLL;
using Sefate.Incubator.WorkItem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.Core.Services
{
    public class WorkItemService : IWorkItemService
	{
		#region Variables
		private RequirementManager requirementManager;
		private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
		#endregion


		public WorkItemRequirements GetWorkItemRequirements(String clientType, String statusCode, string role, int workItemID)
		{
			requirementManager = new RequirementManager();
			return requirementManager.GetWorkItemRequirements(clientType, statusCode,role, workItemID);
		}
		public bool UpdateWorkItemRequirements(WorkItemRequirements workItemRequirements)
		{
			UpdateRequirementResult result = new UpdateRequirementResult();
			return workItemRequirements.UpdateSelf(ref result).Result;
		}

		public WorkItemView CreateWorkIten(int userId, UserView user)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			WorkItemView result = new WorkItemView();
			var workItem = incubatorWorkitemEntitiesManager.CreateWorkItem(1, user.ClientID, userId);
			if (workItem !=0)
			{
				result.WorkItemID = workItem;
				result.PrimaryClient = new Sefate.Incubator.WorkItem.Client(user.ClientID);
				var clientFields = incubatorWorkitemEntitiesManager.CreateIdentityFields(workItem, result.PrimaryClient.ClientName,user.Email, result.PrimaryClient.RegistrationNo);

				if (clientFields == false)
					throw new Exception("Could not add identity fields");
				result.WorkItemStatusInfor = new WorkItemStatusInfor(result.WorkItemID);
			}
			return result;
		}
		public WorkItemView GetWorkIten(int clientID)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			WorkItemView result = new WorkItemView();
			var workItem = incubatorWorkitemEntitiesManager.GetWorkItemByClient(clientID);
			if(workItem !=null)
			{
				result.WorkItemID = workItem.ID;
				result.PrimaryClient = new Sefate.Incubator.WorkItem.Client(clientID);
				result.WorkItemStatusInfor = new WorkItemStatusInfor(workItem.ID);
			}

			return result;
		}

		public bool UpdateWorkItemStatus(WorkItemView item)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			bool result = false;
			int status = 0;
			if (!string.IsNullOrEmpty(item.WorkItemStatusInfor.StatusCode))
			{
				if (int.TryParse(item.WorkItemStatusInfor.StatusCode, out status))
				{
					status++;
					result = incubatorWorkitemEntitiesManager.UpdateWorkItemStage(status.ToString(), item.WorkItemID,item.CurrentUser);
					result &= incubatorWorkitemEntitiesManager.UpdateWorkitemViewStatus(item.WorkItemID);
				}
			}
			return result;
		}
		public bool RejectWorkItem(WorkItemView item)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			bool result = false;
			int status = 0;
			if (!string.IsNullOrEmpty(item.WorkItemStatusInfor.StatusCode))
			{
				if (int.TryParse(item.WorkItemStatusInfor.StatusCode, out status))
				{
					status--;
					result = incubatorWorkitemEntitiesManager.UpdateWorkItemStage(status.ToString(), item.WorkItemID,item.CurrentUser);
					result &= incubatorWorkitemEntitiesManager.UpdateWorkitemViewStatus(item.WorkItemID);
				}
			}
			return result;
		}

		public WorkItemGridView GetAllWorkItems()
		{
			WorkItemGridView result = new WorkItemGridView();
			return result;
		}

		public bool UpdateStatus(StageUpdateView item)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			bool result = incubatorWorkitemEntitiesManager.UpdateWorkItemStage(item.ToStage, item.WorkItemID,item.CurrentUser);
			result &= incubatorWorkitemEntitiesManager.UpdateWorkitemViewStatus(item.WorkItemID);
			return result;
		}
	}
}
