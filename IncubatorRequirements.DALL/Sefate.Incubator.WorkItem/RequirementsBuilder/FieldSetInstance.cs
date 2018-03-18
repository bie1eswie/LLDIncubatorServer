using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public class FieldSetInstance
    {
        public Guid InstanceID { get; set; }
        public int InstanceNumber { get; set; }
        public List<WorkItemField> WorkItemFields { get; set; }
        public string Title { get; set; }
    }
}
