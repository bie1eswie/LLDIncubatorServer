using Sefate.Incubator.WorkItem.DAL;
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
		private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
		public IncubatorQuardrant()
        {
            QuardrantQuarters = new List<Incubation.QuardrantQuarter>();
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

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


            return result;
        }

        public void SetScore()
        {
            ScoreCard = new ScoreCard();
            foreach(var quarter in QuardrantQuarters)
            {
                if (quarter.FieldSetGroups.Any())
                {
                    foreach(var group in quarter.FieldSetGroups)
                    {
                        if (group.FieldSets.Any())
                        {
                            foreach(var fieldSet in group.FieldSets)
                            {
                                if (fieldSet.WorkItemFields.Any())
                                {
                                    foreach(var field in fieldSet.WorkItemFields)
                                    {
                                        if(field.FieldValue=="YES")
                                        ScoreCard.Value = ScoreCard.Value + field.FieldScore;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
