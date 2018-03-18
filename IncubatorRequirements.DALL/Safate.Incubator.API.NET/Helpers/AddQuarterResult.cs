using Safate.Incubator.API.Core.Helpers;
using Sefate.Incubator.Proccess.BLL.Incubation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Helpers
{
    public class AddQuarterResult: GenericResult
    {
		public QuardrantQuarter QuardrantQuarter { get; set; }
	}
}
