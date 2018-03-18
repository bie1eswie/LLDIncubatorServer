using IncubatorRequirements.DAL;
using IncubatorRequirements.DALL;
using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.Requrements.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.InterventionReport
{
   public class InterventionReportManager
    {
        public InterventionReport GetInterventionRequirement(IncubationRequirement incubationRequirement)
        {
            InterventionReport result = new InterventionReport();

            var fields = incubationRequirement.GetWorkItemFields();
            RequirementManager manager = new RequirementManager();
            IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            List<WorkItemField> dataFields = new List<WorkItemField>();
            var reportFields = incubatorWorkitemEntitiesManager.GetReportFields(incubationRequirement.ReportID);
            IncubatorRequirementsManager incubatorRequirementsManager = new IncubatorRequirementsManager();

            if (reportFields!=null && reportFields.Any())
            {
                var fieldGroups = reportFields.GroupBy(x => x.IssueID);

                foreach(var dataGroup in fieldGroups)
                {
                    dataFields = new List<WorkItemField>();
                    foreach (var reportField in reportFields)
                    {
                        var dataField = new WorkItemField()
                        {
                            FieldCode = reportField.FieldCode,
                            FieldSetCode = "30",
                            MapCode = reportField.MapCode,
                            FieldValue = reportField.FieldValue,
                            ID = reportField.ID

                        };
                        dataFields.Add(dataField);
                    }

                    if (fields.Any())
                    {
                        var issueFields = fields.Where(x => x.FieldValue == "NO");
                        if (issueFields != null && issueFields.Any())
                        {
                            var issueFieldsGroups = issueFields.GroupBy(x => x.Group);

                            if (issueFieldsGroups != null && issueFieldsGroups.Any())
                            {
                                foreach (var group in issueFieldsGroups)
                                {
                                    var reqSet = new RequirementsBuilder.FieldSetGroup();
                                    reqSet.Name = group.Key;
                                    int instance = 0;
                                    foreach (var field in group.ToList())
                                    {
                                        var fieldSet = incubatorRequirementsManager.FieldSet("30");
                                        var setFields = manager.BuildFieldSet(fieldSet, group.Key, dataFields, 1, true, false, null, incubationRequirement.WorkItemID, instance);
                                        reqSet.FieldSets.Add(setFields);
                                    }

                                    result.FieldSetGroups.Add(reqSet);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (fields.Any())
                {
                    var issueFields = fields.Where(x => x.FieldValue == "NO");
                    if (issueFields != null && issueFields.Any())
                    {
                        var issueFieldsGroups = issueFields.GroupBy(x => x.Group);
                        int active = 0;
                        if (issueFieldsGroups != null && issueFieldsGroups.Any())
                        {
                            foreach (var group in issueFieldsGroups)
                            {
                                var reqSet = new RequirementsBuilder.FieldSetGroup();

                                if(active==0)
                                {
                                    reqSet.Active = true;
                                }
                                reqSet.Name = group.Key;
                                int instance = 0;
                                foreach (var field in group.ToList())
                                {
                                    var fieldSet = incubatorRequirementsManager.FieldSet("30");
                                    var setFields = manager.BuildFieldSet(fieldSet, group.Key, dataFields, 1, true, false, null, incubationRequirement.WorkItemID, instance);
                                    setFields.Name = field.Name;
                                    reqSet.FieldSets.Add(setFields);
                                }

                                result.FieldSetGroups.Add(reqSet);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
