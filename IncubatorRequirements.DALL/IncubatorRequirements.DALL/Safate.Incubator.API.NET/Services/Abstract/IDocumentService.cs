﻿using Sefate.Incubator.WorkItem;
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
	}
}
