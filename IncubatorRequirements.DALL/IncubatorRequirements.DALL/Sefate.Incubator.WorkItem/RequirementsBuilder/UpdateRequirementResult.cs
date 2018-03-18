using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public class UpdateRequirementResult
    {
        public bool Result { get; set; }
        public string Error { get; set; }
        public List<WorkItemField> UpdatedWorkItemFields { get; set; }

		public UpdateRequirementResult()
		{
			UpdatedWorkItemFields = new List<WorkItemField>();
			Result = true;
		}
	}
}
