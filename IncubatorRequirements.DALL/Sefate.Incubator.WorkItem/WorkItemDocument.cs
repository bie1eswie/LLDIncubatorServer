using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem
{
    public class WorkItemDocument
    {
        public int DocumentID { get; set; }
        public string Code { get; set; }
        public string DocumentRef { get; set; }
        public string DocumentType { get; set; }
        public byte[] DocumentContent { get; set; }
        public string DocumentExt { get; set; }
        public string DocumentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDirty { get; set; }
        public RequirementsBuilder.DocumentStatus DocumentStatus { get; set; }
        public string ContentType { get; set; }
        public bool DocumentApproved { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

        public WorkItemDocument(DAL.Document document)
        {
            DocumentExt = DocumentExt;
            DocumentName = document.DocumentName;
            DocumentID = document.ID;
            DocumentType = document.DocumentType;
            CreatedDate = document.CreatedDate.Value;
            isDirty = false;
            ContentType = document.ContentType;
            DocumentApproved = document.StatusID == 1;
			DocumentStatus = new RequirementsBuilder.DocumentStatus(document.StatusID,document.ID);
        }

        public WorkItemDocument()
        {
        }

        public WorkItemDocument(int documentID)
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();

            var document = incubatorWorkitemEntitiesManager.GetDocument(documentID);
            if (document != null)
            {
                DocumentContent = document.Content;
                DocumentExt = DocumentExt;
                DocumentName = document.DocumentName;
                DocumentID = document.ID;
                DocumentType = document.DocumentType;
                CreatedDate = document.CreatedDate.Value;
                isDirty = false;
                ContentType = document.ContentType;
                DocumentStatus = new RequirementsBuilder.DocumentStatus(document.StatusID,document.ID);
            }
        }

        public bool UpdateStatus(int status)
        {
            return this.DocumentStatus.UpdateDocumentStatus(DocumentID,status);
        }
    }
}
