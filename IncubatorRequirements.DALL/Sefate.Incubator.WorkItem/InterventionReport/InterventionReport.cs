using IncubatorRequirements.DALL;
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.InterventionReport
{
   public class InterventionReport
    {
        public List<RequirementsBuilder.FieldSetGroup> FieldSetGroups { get; set; }
        public Client Client { get; set; }
        public WorkItem WorkItem { get; set; }
        public int ReportID { get; set; }

        public InterventionReport()
        {
            FieldSetGroups = new List<RequirementsBuilder.FieldSetGroup>();
        }

        public bool UpdateSeft()
        {
            IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            bool result = true;
            foreach(var group in FieldSetGroups)
            {
                if (group.FieldSets.Any())
                {
                    foreach(var fieldset in group.FieldSets)
                    {
                        if (fieldset.WorkItemFields.Any())
                        {
                            if (fieldset.isNew)
                            {
                                Guid id = Guid.NewGuid();

                                foreach (var field in fieldset.WorkItemFields)
                                {
                                    if (field.isDirty)
                                    {
                                        incubatorWorkitemEntitiesManager.AddNewReportField(field.Code, 1, id, field.FieldValue, "", field.MapCode);
                                    }
                                }
                            }
                            else if(fieldset.isDirty)
                            {
                                foreach (var field in fieldset.WorkItemFields)
                                {
                                    if (field.isDirty)
                                    {
                                        incubatorWorkitemEntitiesManager.UpdateReportField(field.FieldValue,field.ID);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
