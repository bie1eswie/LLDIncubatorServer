using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem;
using Sefate.Incubator.WorkItem.InterventionReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Services.Abstract
{
    public  interface IDocumentService
    {
		WorkItemDocument GetDocument(int documentID);
		bool UpdateDocumentStatus(int documentID, int statusID);
        byte[] GenreateInterventionReport(InterventionReport IncubatorRequirements);
	}
}
