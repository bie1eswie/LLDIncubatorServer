using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public abstract class BaseComponent
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public abstract UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result);
    }
}
