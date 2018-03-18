using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public class StatusGridViewPage
    {
        public List<WorkItem> WorkItems { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public int PageNumber { get; set; }
        public StatusGridViewPage()
        {
            WorkItems = new List<WorkItem>();
        }
    }
}
