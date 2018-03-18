using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class WorkItemGridView
    {
        public List<WorkItem> WorkItems { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        public WorkItemGridView()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            WorkItems = new List<WorkItem>();
            var dataWorkItems = incubatorWorkitemEntitiesManager.GetAllWorkItems();
            if (dataWorkItems != null)
            {
                foreach (var workIten in dataWorkItems)
                {
                    WorkItem item = new WorkItem(workIten.ClientID.Value);
                    this.WorkItems.Add(item);
                }
            }
        }
    }
}
