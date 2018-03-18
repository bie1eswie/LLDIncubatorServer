using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class UpdateFieldsManager
    {
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        public UpdateFieldsManager()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }
        public UpdateRequirementResult UpdateField(WorkItemField field)
        {
            UpdateRequirementResult result = new RequirementsBuilder.UpdateRequirementResult();
            result.Result = incubatorWorkitemEntitiesManager.UpdateField(field.FieldValue, field.ID,field.QuarterID);
            return result;
        } 
        
        public bool AddNewField(WorkItemField field)
        {
            return incubatorWorkitemEntitiesManager.AddNewField(field.WorkItemID, field.FieldCode, field.FieldValue, field.FieldSetCode, field.MapCode, "", field.IsRelated,field.QuarterID);
        }
        public bool UploadDocument(WorkItemField field)
        {
            return incubatorWorkitemEntitiesManager.CreateDocument(field.WorkItemDocument.DocumentContent, field.MapCode, field.WorkItemDocument.DocumentExt, field.WorkItemDocument.DocumentName, field.WorkItemDocument.DocumentType, field.WorkItemID);
        }
        public bool UpdateDocument(WorkItemField field)
        {
            return incubatorWorkitemEntitiesManager.UpdateDocument(field.FileContent, field.MapCode, field.WorkItemDocument.DocumentExt, field.WorkItemDocument.DocumentName, field.WorkItemDocument.DocumentType, field.WorkItemID, field.WorkItemDocument.DocumentID);
        }
    }
}
