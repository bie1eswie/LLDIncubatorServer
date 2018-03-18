using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
   public enum ComponentType
    {

    }
   public interface UIComponentDefinition
    {
        UIComponentDefinition ConstructComponent();
    }
}
