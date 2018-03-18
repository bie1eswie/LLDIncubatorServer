using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.ViewModels.Notification
{
    public class StatusUpdateView
    {
		public string FromStatus { get; set; }
		public string ToStatus { get; set; }
		public string UserEmail { get; set; }
		public string ClientName { get; set; }

		public IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

		public StatusUpdateView(int toStatus, string clientName, string fromStatus, string userEmail)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
		    FromStatus = fromStatus;
			var toStatusText = incubatorWorkitemEntitiesManager.GetStageByCode(toStatus.ToString());
			if (toStatusText != null)
			{
				ToStatus = toStatusText.StageText;
			}
			ClientName = clientName;
			UserEmail = userEmail;

		}
	}
}
