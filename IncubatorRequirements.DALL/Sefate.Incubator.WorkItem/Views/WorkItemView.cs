using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Views
{
	public class WorkItemView
	{
		public int WorkItemID { get; set; }
		public Guid WorkItemReference { get; set; }
		public WorkItemStatusInfor WorkItemStatusInfor { get; set; }
		public Client PrimaryClient { get; set; }
		public int CurrentRole { get; set; }
		public int CurrentUser { get; set; }

		public WorkItemView(WorkItem workItem)
        {
            this.WorkItemID = workItem.WorkItemID;
            this.WorkItemStatusInfor = workItem.WorkItemStatusInfor;
            this.PrimaryClient = workItem.PrimaryClient;
        }

		public WorkItemView()
		{
		}
	}
}
