using Safate.Incubator.API.NET.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sefate.Incubator.WorkItem;
using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.InterventionReport;

namespace Safate.Incubator.API.NET.Services
{
	public class DocumentService : IDocumentService
	{
		public WorkItemDocument GetDocument(int documentID)
		{
			return new WorkItemDocument(documentID);
		}

		public bool UpdateDocumentStatus(int documentID, int statusID)
		{
			bool result = false;
			var document = new WorkItemDocument(documentID);
			result = document.UpdateStatus(statusID);
			return result;
		}

       public byte[] GenreateInterventionReport(InterventionReport IncubatorRequirements)
        {
            byte[] result = null;
            DocumentManager documentManager = new DocumentManager();
            result = documentManager.GenerateInterventionReport(IncubatorRequirements);
            return result;
        }

    }
}
