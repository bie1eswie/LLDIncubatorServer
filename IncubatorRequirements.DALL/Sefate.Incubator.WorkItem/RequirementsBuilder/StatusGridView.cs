using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class StatusGridView
    {
        public List<WorkItem> WorkItems { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public List<StatusGridViewPage> StatusGridViewPages { get; set; }
        public StatusGridViewPage CurrentPage { get; set; }
        public StatusGridView()
        {
            WorkItems = new List<WorkItem>();
            StatusGridViewPages = new List<StatusGridViewPage>();
        }
    }
}
