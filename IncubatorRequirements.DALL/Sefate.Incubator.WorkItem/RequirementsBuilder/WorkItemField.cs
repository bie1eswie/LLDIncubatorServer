using System;
using System.Collections.Generic;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
	public enum FieldTypeEnum
    {
        CheckBoxList = 1,
        CheckBox = 2,
        DatePicker = 3,
        DropDownList = 4,
        Label = 5,
        MultiLineTextBox = 6,
        TextBox = 7,
        HtmlEditor = 8,
        NumericTextbox = 9,
        NotFound = 0,
        DocumentUploadField = 10
    }
    public class WorkItemField : BaseComponent
    {
        private UpdateFieldsManager updateFieldsManager;
        public string FieldName { get; set; }
        public int ID { get; set; }
        public string FieldCode { get; set; }
        public int? WorkItemID { get; set; }
        public string MapCode { get; set; }
        public string FieldType { get; set; }
        public FieldTypeEnum FieldTypeEnum { get; set; }
        public List<DropdownValue> DropdownValues { get; set; }
        public string WorkItemRef { get; set; }
        public string FieldValue { get; set; }
        public string FieldSetCode { get; set; }
        public WorkItemDocument WorkItemDocument { get; set; }
        public byte[] FileContent { get; set; }
        public string DropDownValueCode { get; set; }
		public bool IsRequired { get; set; }
		public bool isValid { get; set; }
		public string ErrorMessage { get; set; }
		public bool IsEditable { get; set; }
        public bool isDirty

        {
			get;
			set;
        }
        public bool isNew { get; set; }
        public string OriginalFieldValue { get; set; }
        public FieldSetGroup FieldSetGroup { get; set; }
        public bool ShowDependends { get; set; }
		public string ToolTip { get; set; }
        public bool HasToolTip { get; set; }
        public bool HasDependends { get; set; }
        public List<CalculationParameter> CalculationParameters { get; set; }
        public string Calcculator { get; set; }
        public int FieldScore { get; set; }
		public int? QuarterID { get; set; }
		public int FieldValueLength { get; set; }
		public bool IsRelated { get; set; }
        public string Group { get; set; }
        public int SetNumber { get; set; }
		public WorkItemField()
        {
            DropdownValues = new List<RequirementsBuilder.DropdownValue>();
            updateFieldsManager = new RequirementsBuilder.UpdateFieldsManager();
            CalculationParameters = new List<RequirementsBuilder.CalculationParameter>();
        }

        public override UpdateRequirementResult UpdateSelf(ref UpdateRequirementResult result)
        {
            if (isNew)
            {
                if (FieldTypeEnum == FieldTypeEnum.DocumentUploadField)
                {
					if (IsRelated)
						QuarterID = null;
                    result.Result &= updateFieldsManager.UploadDocument(this);
                    result.Result &= updateFieldsManager.AddNewField(this);
                }
                else
                {
					if (this.QuarterID == 0)
						this.QuarterID = null;
					if (IsRelated)
						QuarterID = null;
					result.Result &= updateFieldsManager.AddNewField(this);
                }
                 return result;
            }
            else if (isDirty)
            {
                if (FieldTypeEnum == FieldTypeEnum.DocumentUploadField)
                {
					if (IsRelated)
						QuarterID = null;
					updateFieldsManager.UpdateDocument(this);
                    updateFieldsManager.UpdateField(this);
                }
                else
                {
					if (IsRelated)
						QuarterID = null;
					result.Result &= updateFieldsManager.UpdateField(this).Result;
                }
            }
			return result;
        }

        public static WorkItemDocument CreateDocumentContent(byte[] content, string mapCode, string fileExt, string documentName, string documentType)
        {
            WorkItemDocument result = new Incubator.WorkItem.WorkItemDocument();
            result.CreatedDate = DateTime.Now;
            result.DocumentContent = content;
            result.DocumentExt = fileExt;
            result.DocumentName = documentName;
            result.DocumentType = documentType;
            result.DocumentStatus = new DocumentStatus("Created",1);
            return result;
        }


    }
}
