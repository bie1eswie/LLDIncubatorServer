using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.EventManager
{
	public class IncubatorEvent
	{
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public string StartDateText { get; set; }
		public EventType EventType { get; set; }
        public string EntDateText { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public List<IncubatorEventInvitation> Invitations { get; set; }
	}
}
