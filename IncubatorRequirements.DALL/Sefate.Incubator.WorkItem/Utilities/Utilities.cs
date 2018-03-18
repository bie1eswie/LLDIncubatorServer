using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.Utilities
{
    public class Utilities
    {
        public static FieldTypeEnum ConvertToFieldTypeEnum(string fieldType)
        {
            FieldTypeEnum result = FieldTypeEnum.NotFound;

            int intEnumValue;
            if (int.TryParse(fieldType, out intEnumValue))
            {
                if (Enum.IsDefined(typeof(FieldTypeEnum), intEnumValue))
                {
                    result = (FieldTypeEnum)intEnumValue;
                }
            }
            return result;
        }
    }
}
