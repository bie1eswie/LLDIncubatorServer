using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class FieldSet : BaseComponent
    {
        public string FieldSetGroupCode { get; set; }
        public List<WorkItemField> WorkItemFields { get; set; }
        public List<FieldSetGroup> ChildFieldSetGroups { get; set; }
        public bool isEditable { get; set; }
        public bool isCalculated { get; set; }
        public bool IsHidden { get; set; }
		public bool isDirty{ get { return WorkItemFields.Any(x => x.isDirty); } set { } }
        public bool isNew { get; set; }

		public FieldSet()
        {
            WorkItemFields = new List<WorkItemField>();
            ChildFieldSetGroups = new List<RequirementsBuilder.FieldSetGroup>();
        }
        public void SetIsDirty()
        {
            isDirty = WorkItemFields.Any(x => x.isDirty);
        }
        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            foreach (var field in WorkItemFields)
            {
                if (field.isDirty)
                {
                    var fieldresult = field.UpdateSelf(ref result);
                    result.UpdatedWorkItemFields.Add(field);
                    result.Result &= fieldresult.Result;
                }
            }
            return result;
        }

        public void GetChildFieldSetGroups()
        {
            foreach(var field in WorkItemFields)
            {
                if(field.FieldSetGroup!=null)
                {
                    ChildFieldSetGroups.Add(field.FieldSetGroup);
                }
            }
        }
        public void OrderWorkItemFields()
        {
            if(WorkItemFields!=null&&WorkItemFields.Any())
            WorkItemFields = WorkItemFields.OrderBy(x => x.Order).ToList();
        }
    }
}
