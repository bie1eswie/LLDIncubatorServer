using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public class DropdownValue :BaseComponent
    {
        public List<WorkItemDocument> WorkItemDocuments { get; set; }
        public FieldSetGroup FieldSetGroup { get; set; }
        public bool IsFieldValue { get; set; }

		public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
		{
			throw new NotImplementedException();
		}
	}
}
