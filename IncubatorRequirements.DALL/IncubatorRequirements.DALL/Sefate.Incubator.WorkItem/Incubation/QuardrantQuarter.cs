using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.Incubation;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.Proccess.BLL.Incubation
{
    public class QuardrantQuarter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuarterID { get; set; }
        public int QuardrantID { get; set; }
        public int WorkItem { get; set; }
        public List<QuarterMilestone> QuarterMilestones { get; set; }
        public bool isDirty { get; set; }
        public bool isNew { get; set; }
        public bool Active { get; set; }
		public List<FieldSetGroup> FieldSetGroups { get; set; }
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

        public QuardrantQuarter()
        {
			FieldSetGroups = new List<FieldSetGroup>();
            QuarterMilestones = new List<QuarterMilestone>();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

        }

        public UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            if (isDirty && FieldSetGroups.Any())
            {
                foreach(var group in FieldSetGroups)
                {
                    var update = group.UpdateSelf(ref result);
                    result.Result &= update.Result;
                    result.UpdatedWorkItemFields.AddRange(update.UpdatedWorkItemFields);
                }
            }
            else if (isNew)
            {

				QuarterID =  incubatorWorkitemEntitiesManager.AddQuardrantQuarter(Name, WorkItem, QuardrantID);
            }
            return result;
        }
		public void SetFieldSetGroups(List<FieldSetGroup> fieldSetGroups)
		{
			if (fieldSetGroups != null)
			{
                if (FieldSetGroups != null && FieldSetGroups.Any())
                {
                    FieldSetGroups.AddRange(fieldSetGroups);
                }
                else
                {
                    if (fieldSetGroups != null)
                    {
                        FieldSetGroups = fieldSetGroups;
                    }
                }
			}
		}

        public void SetMileStone()
        {
            if(QuarterID!=0)
            {
                var mileStones = incubatorWorkitemEntitiesManager.GetIncubatorQuarterMileStones(QuarterID);
                if (mileStones != null)
                {
                    foreach(var item in mileStones)
                    {
                        QuarterMilestones.Add(new QuarterMilestone(item));
                    }
                }
            }
        }
	}
}
