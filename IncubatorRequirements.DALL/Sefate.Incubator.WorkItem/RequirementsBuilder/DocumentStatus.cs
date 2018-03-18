using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class DocumentStatus
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager { get; set; }
        public DocumentStatus(string status, int statusID)
        {
            Status = status;
            StatusID = statusID;
        }
		public DocumentStatus()
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
		}


		public DocumentStatus(int statusID,int documentID)
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
           var documentStatus = incubatorWorkitemEntitiesManager.GetDocumentStatus(documentID);
            if (documentStatus != null && documentStatus.StatusID.HasValue)
            {
                var status = incubatorWorkitemEntitiesManager.DocumentStatus(documentStatus.StatusID.Value);
                if (status != null)
                {
                    this.Status = status.DocumentReview;
                    this.StatusID = status.ID;
                }
            }
        }

        public bool UpdateDocumentStatus(int documentID,int status)
        {
            bool result = false;
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            result = incubatorWorkitemEntitiesManager.UpdateDocumentStatus(status, documentID);
            return result;
        }
    }
}
