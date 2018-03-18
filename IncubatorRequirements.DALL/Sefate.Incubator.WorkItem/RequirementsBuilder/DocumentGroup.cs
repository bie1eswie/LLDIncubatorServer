using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class DocumentGroup
    {
        public string Name { get; set; }
        public bool CanEdit { get; set; }
        public List<WorkItemField> DocumentFields { get; set; }
        public WorkItemDocumentStatusInfor WorkItemStatusInfor { get; set; }

        public DocumentGroup(int workItem)
        {
            DocumentFields = new List<RequirementsBuilder.WorkItemField>();
            WorkItemStatusInfor = new WorkItemDocumentStatusInfor(workItem);
            Name = "Documents";
        }
    }
}
