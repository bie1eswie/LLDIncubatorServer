using Sefate.Incubator.WorkItem.Requrements.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class WorkItemRequirements : BaseComponent
    {
        public List<RequirementsTab> RequirementsTabs { get; set; }
        private RequirementManager requirementManager;
        public List<WorkItemStage> WorkItemStages { get; set; }
        public DocumentGroup DocumentsTab { get; set; }
        public bool HasDocuments { get; set; }
        public bool isEditable { get; set; }
        public WorkItemStage CurrentWorkItemStage { get; set; }
        public bool isDirty
        {
            get
            {
                return RequirementsTabs.Any(x => x.isDirty);
            }
            set
            {

            }
        }
        public WorkItemRequirements()
        {
            RequirementsTabs = new List<RequirementsTab>();
            requirementManager = new RequirementManager();
            WorkItemStages = new List<RequirementsBuilder.WorkItemStage>();
        }

        public WorkItemRequirements(String clientType, String statusCode, List<Incubator.WorkItem.DAL.WorkItemField> workItemData,string role, int workItemID)
        {
            requirementManager = new RequirementManager();
            var requirement = requirementManager.BuildWorkItemRequirements(clientType, statusCode, workItemData,role, workItemID);
            RequirementsTabs = requirement.RequirementsTabs;
        }

        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            foreach (var field in RequirementsTabs)
            {
                if (field.isDirty)
                {
                    var fieldresult = field.UpdateSelf(ref result);
                    result.Result &= fieldresult.Result;
                }
            }
            return result;
        }

        public List<WorkItemField> GetFields()
        {
            List<WorkItemField> result = new List<WorkItemField>();

            foreach (var tab in RequirementsTabs)
            {
                if (tab.FieldSetGroups != null && tab.FieldSetGroups.Any())
                {
                    foreach (var group in tab.FieldSetGroups)
                    {
                        if (group.FieldSets != null && group.FieldSets.Any())
                        {
                            foreach (var fieldSet in group.FieldSets)
                            {
                                if (fieldSet.WorkItemFields != null)
                                {
                                    result.AddRange(fieldSet.WorkItemFields);
                                    foreach (var field in fieldSet.WorkItemFields)
                                    {
                                        if (field.DropdownValues != null)
                                        {
                                            if (!string.IsNullOrEmpty(field.FieldValue) && field.FieldSetGroup != null)
                                            {
                                                result.AddRange(field.FieldSetGroup.GetFields());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public List<WorkItemField> GetDocumentFields()
        {
            List<WorkItemField> result = new List<RequirementsBuilder.WorkItemField>();
            result = GetFields();
            if (result != null && result.Any())
            {
                result = result.Where(x => x.FieldTypeEnum == FieldTypeEnum.DocumentUploadField && !string.IsNullOrEmpty(x.FieldValue) && x.WorkItemDocument != null).ToList();
            }
            return result;
        }

        public List<WorkItemField> GetWorkItemDocuments()
        {
            var workItemFields = GetFields();
            var result = workItemFields.Where(x => x.FieldType == "DocumentUploadField" && !string.IsNullOrEmpty(x.FieldValue) && x.WorkItemDocument != null);
            return result.ToList();
        }
    }
}
