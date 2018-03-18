using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class CalculationParameter : BaseComponent
    {
        public string MapCode { get; set; }
        public string FieldCode { get; set; }
        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            throw new NotImplementedException();
        }
    }
}
