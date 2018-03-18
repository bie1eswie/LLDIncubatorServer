using Microsoft.AspNetCore.Http;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Helpers
{
	public class DocumentField
	{
		public IFormFile File { get; set; }
		public WorkItemField Field { get; set; }

		public DocumentField()
		{

		}

	}
}
