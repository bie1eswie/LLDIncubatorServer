using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Views
{
    public class StageUpdateView
    {
       public string Reason { get; set; }
	   public string comment { get; set; }
	   public string ToStage { get; set; }
	   public bool isReject { get; set; }
	   public string FromStage { get; set; }
	   public int WorkItemID { get; set; }
	   public int CurrentUser { get; set; }
		public StageUpdateView(int workItemID, string toStage)
		{
			WorkItemID = workItemID;
			ToStage = toStage;
		}
	}
}
