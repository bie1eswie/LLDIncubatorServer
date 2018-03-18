using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Services.Abstract
{
   public interface IWorkItemService
    { 
		 WorkItemRequirements GetWorkItemRequirements(String clientType, String statusCode,string role, int workItemID);
		 bool UpdateWorkItemRequirements(WorkItemRequirements workItemRequirements);
		 WorkItemView CreateWorkIten(int userId,UserView user);
		 WorkItemView GetWorkIten(int clientID);
		 bool UpdateWorkItemStatus(WorkItemView nextStage);
		 bool UpdateStatus(StageUpdateView item);
		WorkItemGridView GetAllWorkItems();
	}
}
