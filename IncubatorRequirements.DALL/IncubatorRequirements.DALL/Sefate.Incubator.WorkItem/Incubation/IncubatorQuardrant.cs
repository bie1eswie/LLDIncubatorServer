using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.Proccess.BLL.Incubation
{
    public class IncubatorQuardrant
    {
        public ScoreCard ScoreCard { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IncubatorQuardrantID { get; set; }
        public List<QuardrantQuarter> QuardrantQuarters { get; set; }
        public IncubatorQuardrant()
        {
            QuardrantQuarters = new List<Incubation.QuardrantQuarter>();
        }

        public UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            foreach (var quarter in QuardrantQuarters)
            {
                if (quarter.isDirty)
                {
                    var fieldresult = quarter.UpdateSelf(ref result);
                    result.Result &= fieldresult.Result;
                }
            }
            if (result.Result)
            {
                foreach(var quarter in QuardrantQuarters)
                {
                    foreach (var setGroup in quarter.FieldSetGroups)
                    {
                        foreach (var fieldset in setGroup.FieldSets)
                        {
                            foreach (var field in fieldset.WorkItemFields)
                            {
                                ScoreCard.Value = ScoreCard.Value + field.FieldScore;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
