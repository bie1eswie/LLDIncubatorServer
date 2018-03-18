using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class FieldSetGroup : BaseComponent
    {
        public List<FieldSet> FieldSets { get; set; }
        public string RequirementTabCode { get; set; }
        public bool isEditable { get; set; }
        public bool isDirty
        {
            get
            {
                return FieldSets.Any(x => x.isDirty);
            }
            set
            {

            }
        }

        public FieldSetGroup()
        {
            FieldSets = new List<RequirementsBuilder.FieldSet>();
        }

        public void SetIsDirty()
        {
            isDirty = FieldSets.Any(x => x.isDirty);
        }

        public bool Active { get; set; }

        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            foreach (var field in FieldSets)
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

            if (FieldSets != null && FieldSets.Any())
            {
                foreach (var fieldSet in FieldSets)
                {
                    if (fieldSet.WorkItemFields != null)
                    {
                        result.AddRange(fieldSet.WorkItemFields);
                        foreach (var field in fieldSet.WorkItemFields)
                        {
                            if (field.DropdownValues != null)
                            {
                                if (!string.IsNullOrEmpty(field.FieldValue))
                                {
                                    foreach (var dropdownValue in field.DropdownValues)
                                    {
                                        if (field.FieldValue == dropdownValue.Code && dropdownValue.FieldSetGroup!=null)
                                        {
                                            result.AddRange(dropdownValue.FieldSetGroup.GetFields());
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

        public void GetChildDependents()
        {
			List<FieldSet> allDependentFieldSets = new List<FieldSet>();
            foreach(var fieldset in FieldSets)
            {
                fieldset.GetChildFieldSetGroups();
                if(fieldset.ChildFieldSetGroups != null && fieldset.ChildFieldSetGroups.Any())
                {
                    foreach(var childGroup in fieldset.ChildFieldSetGroups)
                    {
                        if(childGroup.FieldSets!=null&& childGroup.FieldSets.Any())
                        {
							allDependentFieldSets.AddRange(childGroup.FieldSets);
                        }
                    }
                }
            }
			this.FieldSets.AddRange(allDependentFieldSets);
        }

        public void OrderFieldSets()
        {
            foreach(var fieldset in FieldSets)
            {
                fieldset.OrderWorkItemFields();
            }
            if(FieldSets!=null&& FieldSets.Any())
            FieldSets = FieldSets.OrderBy(x => x.Order).ToList();
        }
    }
}
