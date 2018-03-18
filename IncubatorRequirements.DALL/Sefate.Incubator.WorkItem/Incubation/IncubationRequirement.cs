using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.Proccess.BLL.Incubation
{
    public class IncubationRequirement
    {
        public int WorkItemID { get; set; }
        public List<IncubatorQuardrant> IncubatorQuardrants { get; set; }
        public int ReportID { get; set; }
        public IncubationRequirement()
        {
            IncubatorQuardrants = new List<Incubation.IncubatorQuardrant>();
        }

        public void SetIncubatorQuardrants()
        {

        }
        public UpdateRequirementResult UpdateSelf(UpdateRequirementResult result)
        {
            foreach(var quardrant in IncubatorQuardrants)
            {
				quardrant.UpdateSelf(ref result);
            }
            return result;
        }

        public  List<WorkItemField> GetWorkItemFields()
        {
            List<WorkItemField> result = new List<WorkItemField>();
            foreach (var quard in IncubatorQuardrants)
            {
                if (quard.QuardrantQuarters.Any())
                {
                    foreach(var quarter in quard.QuardrantQuarters)
                    {
                        if (quarter.FieldSetGroups.Any())
                        {
                            foreach(var reqSet in quarter.FieldSetGroups)
                            {
                                var fields = reqSet.GetFields();
                                result.AddRange(fields);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
