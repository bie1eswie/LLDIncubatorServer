using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class RequirementsTab : BaseComponent
    {
        public List<FieldSetGroup> FieldSetGroups { get; set; }
		public bool Active { get; set; }
		public bool isEditable { get; set; }
        public bool isDirty
        {
            get
            {
                return FieldSetGroups.Any(x => x.isDirty);
            }
            set
            {

            }
        }
        public RequirementsTab(string code, string name,int index)
        {
            this.Code = code;
            this.Description = name;
            this.Name = name;
            FieldSetGroups = new List<FieldSetGroup>();
			Active = index == 0;
        }

        public void SetIsDirty()
        {
            isDirty = FieldSetGroups.Any(x => x.isDirty);
        }

        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            foreach (var field in FieldSetGroups)
            {
                if (field.isDirty)
                {
                    var fieldresult = field.UpdateSelf(ref result);
                    result.Result &= fieldresult.Result;
                }
            }
            return result;
        }

        public void OrderFieldSetGroups()
        {
            if(FieldSetGroups!=null && FieldSetGroups.Any())
            FieldSetGroups = FieldSetGroups.OrderBy(x => x.Order).ToList();
        }
    }
}
