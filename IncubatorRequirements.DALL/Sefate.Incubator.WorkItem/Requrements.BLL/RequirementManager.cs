using IncubatorRequirements.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.Utilities;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.Proccess.BLL.Incubation;

namespace Sefate.Incubator.WorkItem.Requrements.BLL
{

    public class RequirementManager
    {
        private IncubatorRequirementsManager incubatorRequirementsManager { get; set; }
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager { get; set; }
        public RequirementManager()
        {
            incubatorRequirementsManager = new IncubatorRequirementsManager();
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }

        public bool IsCurrentlyEditable(string statusCode, string roleCode)
        {
            bool result = false;

            var stageMaps = incubatorRequirementsManager.GetWorkItemStageByCode(statusCode);
            if (roleCode == "1")
            {
                result = stageMaps.UserCanEdit_Code == "YES";
            }
            else
            {
                result = stageMaps.BussinessCanEdit_Code == "YES";
            }
            return result;
        }

        public WorkItemRequirements GetIncubatorRequirements(String quardrantCode, int workItemID, int quarterID)
        {
            var workItemData = incubatorWorkitemEntitiesManager.GetQuarterFields(workItemID, quarterID);
            var requirement = BuildIncubatorRequirements(quardrantCode, workItemData, workItemID,quarterID);
            return requirement;
        }

        public List<FieldSetGroup> GetQuarterRequirements(String quardrantCode, int workItemID, int quarterID)
        {
            var workItemData = incubatorWorkitemEntitiesManager.GetQuarterFields(workItemID, quarterID);
            var requirement = BuildQuarterRequirements(quardrantCode, workItemData, workItemID, quarterID);
			if (requirement != null && requirement.Any())
			{
				foreach (var fieldGroup in requirement)
				{
					fieldGroup.GetChildDependents();
					fieldGroup.OrderFieldSets();
				}
			}
			return requirement;
        }

        public IncubationRequirement GetIncubationRequirement(int workItemID)
        {
            IncubationRequirement result = new Proccess.BLL.Incubation.IncubationRequirement();
            var quardrants = incubatorRequirementsManager.IncubatorQuardrants();
            foreach (var quardrant in quardrants)
            {
                if (quardrant != null)
                {
                    var quardrantBLL = new Proccess.BLL.Incubation.IncubatorQuardrant();
                    var databaseQuardrant = incubatorWorkitemEntitiesManager.GetIncubatorQuardrantByCode(quardrant.Code);

                    if (databaseQuardrant != null)
                    {
                        var quardrantQuarters = incubatorWorkitemEntitiesManager.GetIncubatorQuardrantQuarters(databaseQuardrant.IncubatorQuardrantID, workItemID);
                        if (quardrantQuarters != null && quardrantQuarters.Any())
                        {
                            int index = 0;
                            foreach (var quarter in quardrantQuarters)
                            {
                                QuardrantQuarter quardrantQuarter = new QuardrantQuarter();
                                quardrantQuarter.Name = quarter.Quarder;
                                quardrantQuarter.QuarterID = quarter.IncubatorQuarterID;
                                var quarterRequirement = GetQuarterRequirements(quardrant.Code, workItemID, quarter.IncubatorQuarterID);
                                quardrantQuarter.SetFieldSetGroups(quarterRequirement);
                                quardrantQuarter.Active = index == 0;
                                quardrantQuarter.SetMileStone();
                                quardrantBLL.QuardrantQuarters.Add(quardrantQuarter);


                            }
                        }
                        else
                        {
                            //add first quarter
                            var quarter = incubatorWorkitemEntitiesManager.AddQuardrantQuarter("First Quarter", workItemID, quardrant.ID);
                            QuardrantQuarter quardrantQuarter = new QuardrantQuarter();
                            quardrantQuarter.Name = "Quarter 1";
                            quardrantQuarter.Active = true;
                            quardrantQuarter.QuarterID = quarter;
                            var quarterRequirement = GetQuarterRequirements(quardrant.Code, workItemID, quarter);
                            quardrantQuarter.SetFieldSetGroups(quarterRequirement);
                            quardrantBLL.QuardrantQuarters.Add(quardrantQuarter);
                        }
                    }
                    quardrantBLL.IncubatorQuardrantID = databaseQuardrant.IncubatorQuardrantID;
                    quardrantBLL.Name = databaseQuardrant.IncubatorQuardrantText;
                    quardrantBLL.IncubatorQuardrantID = databaseQuardrant.IncubatorQuardrantID;
                    quardrantBLL.SetScore();
                    result.IncubatorQuardrants.Add(quardrantBLL);
                }
            }

			return result;
        }

        public WorkItemRequirements GetWorkItemRequirements(String clientType, String statusCode, string roleCode, int workItemID)
        {
            var workItemData = incubatorWorkitemEntitiesManager.GetWorkItemFields(workItemID);
            var requirement = BuildWorkItemRequirements(clientType, statusCode, workItemData, roleCode, workItemID);

            if (requirement.RequirementsTabs != null && requirement.RequirementsTabs.Any())
            {
                foreach (var reqTab in requirement.RequirementsTabs)
                {
                    if (reqTab.FieldSetGroups != null && reqTab.FieldSetGroups.Any())
                    {
                        foreach (var fieldGroup in reqTab.FieldSetGroups)
                        {
                            fieldGroup.GetChildDependents();
                            fieldGroup.OrderFieldSets();
                        }
                    }
                }
            }
            return requirement;
        }

        public WorkItemRequirements BuildWorkItemRequirements(String clientType, String statusCode, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, string roleCode, int workItemID)
        {
            WorkItemRequirements result = new RequirementsBuilder.WorkItemRequirements();
            //get the client requirements
            int index = 0;
            var requirementsMapping = incubatorRequirementsManager.GetRequirementMapping(statusCode, clientType);
            if (requirementsMapping != null && requirementsMapping.Any())
            {
                var requirementTabs = from a in requirementsMapping
                                      group a by new { a.RequirementsTab_Code, a.RequirementsTab_Name } into b
                                      select b;

                if (requirementTabs != null && requirementTabs.Any())
                {
                    foreach (var reqTab in requirementTabs)
                    {
                        var requirementTab = new RequirementsTab(reqTab.Key.RequirementsTab_Code, reqTab.Key.RequirementsTab_Name, index);
                        var fieldSetGroups = reqTab.ToList();

                        if (fieldSetGroups != null && fieldSetGroups.Any())
                        {
                            foreach (var group in fieldSetGroups)
                            {
                                if (!string.IsNullOrEmpty(group.FieldSetGroup_Code))
                                {
                                    bool editable = IsCurrentlyEditable(statusCode, roleCode) || (group.WorkItemStatus_Code == statusCode);
                                    var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(group.FieldSetGroup_Code);
                                    int groupOrder = 0;
                                    //if (!string.IsNullOrEmpty(group.FieldSetGroupOrder))
                                    //{
                                    //    groupOrder = Convert.ToInt32(group.FieldSetGroupOrder);
                                    //}
                                    var requirementSet = this.BuildFieldSetGroup(fieldSetGroup, workItemData, groupOrder, editable,null, false, workItemID);
                                    if (requirementSet != null)
                                    {
                                        requirementTab.FieldSetGroups.Add(requirementSet);
                                    }
                                }
                            }
                        }
                        result.RequirementsTabs.Add(requirementTab);
                        index++;
                    }
                }
            }
            bool hasDocuments = false;
            var stages = incubatorRequirementsManager.GetWorkItemStages();
            if (stages != null)
            {
                result.WorkItemStages = new List<RequirementsBuilder.WorkItemStage>();
                foreach (var stage in stages)
                {
                    bool isActive = stage.Code == statusCode;
                    var currentStage = new RequirementsBuilder.WorkItemStage(stage.Name, stage.Code, isActive, stage.HasDocuments_Code);

                    result.WorkItemStages.Add(currentStage);
                    if (isActive && stage.HasDocuments_Code == "1")
                    {
                        result.CurrentWorkItemStage = currentStage;
                        hasDocuments = true;
                        break;
                    }
                    else if (isActive)
                    {
                        result.CurrentWorkItemStage = currentStage;
                        break;
                    }
                }
            }
            if (hasDocuments)
            {
                result.DocumentsTab = new RequirementsBuilder.DocumentGroup(workItemID);
                result.HasDocuments = true;
                result.DocumentsTab.CanEdit = roleCode != "1";
                result.DocumentsTab.DocumentFields = result.GetWorkItemDocuments();
            }
            return result;
        }

        public WorkItemRequirements BuildIncubatorRequirements(String quardrantCode, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, int workItemID, int quarter)
        {
            WorkItemRequirements result = new RequirementsBuilder.WorkItemRequirements();
            //get the client requirements
            int index = 0;
            var requirementsMapping = incubatorRequirementsManager.GetRequirementMapping(quardrantCode);
            if (requirementsMapping != null && requirementsMapping.Any())
            {
                var requirementTabs = from a in requirementsMapping
                                      group a by new { a.RequirementsTab_Code, a.RequirementsTab_Name } into b
                                      select b;

                if (requirementTabs != null && requirementTabs.Any())
                {
                    foreach (var reqTab in requirementTabs)
                    {
                        var requirementTab = new RequirementsTab(reqTab.Key.RequirementsTab_Code, reqTab.Key.RequirementsTab_Name, index);
                        var fieldSetGroups = reqTab.ToList();

                        if (fieldSetGroups != null && fieldSetGroups.Any())
                        {
                            foreach (var group in fieldSetGroups)
                            {
                                if (!string.IsNullOrEmpty(group.FieldSetGroup_Code))
                                {
                                    var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(group.FieldSetGroup_Code);
                                    int groupOrder = 0;
                                    if (!string.IsNullOrEmpty(group.FieldSetGroupOrder))
                                    {
                                        int.TryParse(group.FieldSetGroupOrder,out groupOrder);
                                    }
                                    var requirementSet = this.BuildFieldSetGroup(fieldSetGroup, workItemData, groupOrder, true,quarter, false, workItemID);
                                    if (requirementSet != null)
                                    {
                                        requirementTab.FieldSetGroups.Add(requirementSet);
                                    }
                                }
                            }
                        }
                        result.RequirementsTabs.Add(requirementTab);
                        index++;
                    }
                }
            }
            return result;
        }

        public List<FieldSetGroup> BuildQuarterRequirements(String quardrantCode, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, int workItemID,int quarterID)
        {
            List<FieldSetGroup> result = new List<RequirementsBuilder.FieldSetGroup>();
            int index = 0;
            var requirementsMapping = incubatorRequirementsManager.GetRequirementMapping(quardrantCode);
            if (requirementsMapping != null && requirementsMapping.Any())
            {
                var requirementTabs = from a in requirementsMapping
                                      group a by new { a.RequirementsTab_Code, a.RequirementsTab_Name } into b
                                      select b;

                if (requirementTabs != null && requirementTabs.Any())
                {
                    foreach (var reqTab in requirementTabs)
                    {
                        var requirementTab = new RequirementsTab(reqTab.Key.RequirementsTab_Code, reqTab.Key.RequirementsTab_Name, index);
                        var fieldSetGroups = reqTab.ToList();

                        if (fieldSetGroups != null && fieldSetGroups.Any())
                        {
                            foreach (var group in fieldSetGroups)
                            {
                                if (!string.IsNullOrEmpty(group.FieldSetGroup_Code))
                                {
                                    var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(group.FieldSetGroup_Code);
                                    int groupOrder = 0;
                                    if (!string.IsNullOrEmpty(group.FieldSetGroupOrder))
                                    {
                                        int.TryParse(group.FieldSetGroupOrder,out groupOrder);
                                    }
                                    var requirementSet = this.BuildFieldSetGroup(fieldSetGroup, workItemData, groupOrder, true, quarterID, false, workItemID);
                                    if (requirementSet != null)
                                    {
                                        result.Add(requirementSet);
                                    }
                                }
                            }
                        }
                        //result.RequirementsTabs.Add(requirementTab);
                        index++;
                    }
                }
            }
            return result;
        }

        public FieldSetGroup BuildFieldSetGroup(Requirements.DAL.FieldSetGroup fieldSetGroup, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, int order, bool isEditable, int? quarterID = null, bool isHidden = false, int? workItemID = null)
        {
            FieldSetGroup result = new FieldSetGroup();
            if (fieldSetGroup!=null)
            {
                result.Code = fieldSetGroup.Code;
                result.Description = fieldSetGroup.Name;
                result.Name = fieldSetGroup.Name;
                result.Order = order;
                var fieldSetGroupMaps = incubatorRequirementsManager.FieldSetGroupMaps(result.Code);

                if (fieldSetGroupMaps != null && fieldSetGroupMaps.Any())
                {
                    foreach (var fieldSetGroupMap in fieldSetGroupMaps)
                    {
                        var fieldSetInMap = incubatorRequirementsManager.FieldSet(fieldSetGroupMap.FieldSet_Code);
                        if (fieldSetInMap != null)
                        {
                            int setOrder = 0;
                            if (!string.IsNullOrEmpty(fieldSetGroupMap.FieldSetOrder))
                            {
                                int.TryParse(fieldSetGroupMap.FieldSetOrder, out setOrder);
                            }

                            var fieldSet = BuildFieldSet(fieldSetInMap, result.Name, workItemData, setOrder, isEditable, isHidden, quarterID, workItemID);
                            result.FieldSets.Add(fieldSet);
                        }
                    }
                }
            }

            return result;
        }

        public FieldSet BuildFieldSet(Requirements.DAL.FieldSet fieldSet,string setGroup, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, int order, bool editable, bool isHidden, int? quarterID=null, int? workItemID = null, int? instance=null)
        {
            FieldSet result = new RequirementsBuilder.FieldSet();
            if (fieldSet != null)
            {
                result.Code = fieldSet.Code;
                result.Description = fieldSet.Description;
                result.Name = fieldSet.Name;
                result.Order = order;
                result.isEditable = editable;
                result.isCalculated = fieldSet.IsCalculated_Code == "1";
                result.IsHidden = fieldSet.IsHidden_Code == "1" || isHidden;
                var fieldSetMaps = incubatorRequirementsManager.FieldSetMaps(result.Code);
                bool dataAvaliable = true;
                if (fieldSetMaps != null && fieldSetMaps.Any())
                {
                    //build the fields for the field set
                    foreach (var fieldSetMap in fieldSetMaps)
                    {
                        int fieldOrder = 0;
                        if (!string.IsNullOrEmpty(fieldSetMap.FieldOrder))
                        {
                            int.TryParse(fieldSetMap.FieldOrder, out fieldOrder);
                        }
                        var field = BuildField(fieldSetMap, setGroup, workItemData, fieldOrder, editable, quarterID, workItemID);
                        if (field != null)
                        {
                            dataAvaliable &= string.IsNullOrEmpty(field.FieldValue);
                            result.WorkItemFields.Add(field);
                        }
                    }
                    if (result.IsHidden)
                        result.IsHidden = dataAvaliable;
                }
            }

            return result;
        }

        public Sefate.Incubator.WorkItem.RequirementsBuilder.WorkItemField BuildField(Requirements.DAL.FieldSetMap fieldSetMap,string group, List<Incubator.WorkItem.DAL.WorkItemField> workItemData, int order, bool editable,int? quarterID=null, int? workItemID = null,int? instance=null)
        {
            if (fieldSetMap != null)
            {
                Sefate.Incubator.WorkItem.RequirementsBuilder.WorkItemField result = new RequirementsBuilder.WorkItemField();
                result.FieldCode = fieldSetMap.Field_Code;
                result.FieldName = fieldSetMap.Field_Name;
                result.FieldSetCode = fieldSetMap.FieldSet_Code;
                result.Code = fieldSetMap.Field_Code;
                result.Description = fieldSetMap.Field_Name;
                result.Name = fieldSetMap.Field_Name;
                result.MapCode = fieldSetMap.Code;
                result.Order = order;
                result.Group = group;
                result.SetNumber = instance == null ? 0 : instance.Value;
                result.isValid = true;
				if(!string.IsNullOrEmpty(fieldSetMap.FieldScore))
                {
                    int value;
                    bool boolValue = int.TryParse(fieldSetMap.IsRequired_Code, out value);
                    if (boolValue)
                    {
                        result.FieldScore = value;
                    }
                }
                result.IsEditable = editable;
                result.WorkItemID = workItemID;
				if(quarterID.HasValue)
				result.QuarterID = quarterID.Value;
				if (!string.IsNullOrEmpty(fieldSetMap.Length))
                {
                    int value = 0;
                    var boolValue = int.TryParse(fieldSetMap.Length, out value);
                   if (boolValue)
                    {
                        result.FieldValueLength = value;
                    }
                }
					
				else result.FieldValueLength = 255;
				if (!string.IsNullOrEmpty(fieldSetMap.ToolTip))
                {
                    result.HasToolTip = true;
                    result.ToolTip = fieldSetMap.ToolTip;
                }
                if (!string.IsNullOrEmpty(fieldSetMap.IsRequired_Code))
                {
                    int value;
                    bool boolValue = int.TryParse(fieldSetMap.IsRequired_Code, out value);
                    if (boolValue)
                    {
                        result.IsRequired = Convert.ToBoolean(value);
                    }
                }
				if (!string.IsNullOrEmpty(fieldSetMap.IsRelated_Code))
                {
                    int value;
                    bool boolValue = int.TryParse(fieldSetMap.IsRelated_Code,out value);
                    if (boolValue)
                    {
                        result.IsRelated = Convert.ToBoolean(value);
                    }
                }
					

				if (!string.IsNullOrEmpty(fieldSetMap.Field_Code))
                {
                    var clientField = incubatorRequirementsManager.ClientField(fieldSetMap.Field_Code);
                    if (clientField != null)
                    {
                        result.FieldType = clientField.FieldType_Name;
                        if (!string.IsNullOrEmpty(result.FieldType))
                        {
                            result.FieldTypeEnum = Incubator.Utilities.Utilities.ConvertToFieldTypeEnum(result.FieldType);
                        }
                        if (result.FieldType != "DocumentUploadField")
                        {
                            var dataField = GetFieldValueFromDataField(fieldSetMap.Code, workItemData,quarterID,result.IsRelated,instance);

                            if (dataField != null)
                            {
                                result.FieldValue = dataField.FieldValue;
                                result.ID = dataField.ID;
                                result.WorkItemID = dataField.WorkItemID;

                            }
                            else
                            {
                                if (workItemID.HasValue)
                                {
                                    result.WorkItemID = workItemID.Value;
                                }
                                result.isNew = true;
                            }
                        }
                        else
                        {
                            var documentContent = GetDocument(result.MapCode, workItemID);
                            if (documentContent != null)
                            {
                                result.WorkItemDocument = new WorkItemDocument(documentContent);
                                result.FieldValue = documentContent.DocumentName;
                            }
                            else
                            {
                                result.isNew = true;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(fieldSetMap.DropdownSet_Code))
                {
                    var dropDownSet = incubatorRequirementsManager.GetDropdownSet(fieldSetMap.DropdownSet_Code);
                    if (dropDownSet != null)
                    {
                        var dropdownSetMaps = incubatorRequirementsManager.DropdownSetMap(dropDownSet.Code);
                        if (dropdownSetMaps != null && dropdownSetMaps.Any())
                        {
                            //build the drop down values
                            foreach (var dropdownvalue in dropdownSetMaps)
                            {
                                var value = new DropdownValue();
                                value.Code = dropdownvalue.DropdownValue_Code;
                                value.Name = dropdownvalue.DropdownValue_Name;

                                if (!string.IsNullOrEmpty(dropdownvalue.FieldSetGroup_Code))
                                {
                                    value.IsFieldValue = result.DropDownValueCode == dropdownvalue.Code;
                                    if (!string.IsNullOrEmpty(result.FieldValue))
                                    {
                                        if (result.FieldValue.Trim() == value.Name.Trim())
                                        {
                                            var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(dropdownvalue.FieldSetGroup_Code);
                                            result.FieldSetGroup = BuildFieldSetGroup(fieldSetGroup, workItemData, 100, editable,quarterID, false, workItemID);
                                            result.ShowDependends = true;
                                            value.FieldSetGroup = result.FieldSetGroup;
                                        }
                                        else
                                        {
                                            var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(dropdownvalue.FieldSetGroup_Code);
                                            //if (result.FieldValue.Trim() == value.Name.Trim())
                                            //{
                                            result.FieldSetGroup = BuildFieldSetGroup(fieldSetGroup, workItemData, 100, editable,quarterID, true, workItemID);
                                            result.ShowDependends = true;
                                            value.FieldSetGroup = result.FieldSetGroup;
                                            //}
                                        }
                                    }
                                    else
                                    {
                                        var fieldSetGroup = incubatorRequirementsManager.GetFieldSetGroupByCode(dropdownvalue.FieldSetGroup_Code);
                                        //if (result.FieldValue.Trim() == value.Name.Trim())
                                        //{
                                        result.FieldSetGroup = BuildFieldSetGroup(fieldSetGroup, workItemData, 100, editable,quarterID, true, workItemID);
                                        result.ShowDependends = true;
                                        value.FieldSetGroup = result.FieldSetGroup;
                                        //}
                                    }
                                    result.HasDependends = true;
                                }
                                result.DropdownValues.Add(value);
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(fieldSetMap.Caculation_Code))
                {
                    var calculation = incubatorRequirementsManager.GetCalculation(fieldSetMap.Caculation_Code);
                    if (calculation != null)
                    {
                        var parameters = incubatorRequirementsManager.GetCalculationMaps(calculation.Code);
                        if (parameters != null && parameters.Any())
                        {
                            foreach (var param in parameters)
                            {
                                CalculationParameter fieldParam = new CalculationParameter();
                                var paramMap = incubatorRequirementsManager.GetFieldSetMap(param.Parameter_Code);
                                fieldParam.FieldCode = paramMap.Field_Code;
                                fieldParam.MapCode = paramMap.Code;
                                result.CalculationParameters.Add(fieldParam);
                            }
                        }
                        result.Calcculator = calculation.Name;
                        if (!string.IsNullOrEmpty(fieldSetMap.FieldScore))
                        {
                            result.FieldScore = Int32.Parse(fieldSetMap.FieldScore);
                        }
                    }
                }
                return result;
            }
            return null;

        }

        public Sefate.Incubator.WorkItem.RequirementsBuilder.WorkItemField GetField(string mapCode,int workitem)
        {
            var field = incubatorRequirementsManager.GetFieldSetMap(mapCode);
            if(field!=null)
            {
                IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManagern = new IncubatorWorkitemEntitiesManager();
                var workitemFields = incubatorWorkitemEntitiesManagern.GetWorkItemFields(workitem);
                return BuildField(field,"", workitemFields, 1, true, workitem);
            }
            return null;
        }

		public string GetFieldValue(string mapCode, int workitem)
		{
			return incubatorWorkitemEntitiesManager.GetWorkItemFieldValue(mapCode,workitem);
		}
		public DAL.WorkItemField GetFieldValueFromDataField(string mapCode, List<Incubator.WorkItem.DAL.WorkItemField> workItemData,int? quarterID,bool isRelated,int? instance)
        {
            if (workItemData != null)
            {
                DAL.WorkItemField result = null;
                var fieldList = from a in workItemData
                                where ((a.MapCode == mapCode && a.WorkItemQuarterID == quarterID) || (a.MapCode == mapCode && a.WorkItemQuarterID == null && isRelated))
                                select a;



                if (fieldList != null && fieldList.Any())
                {
                    var field = fieldList.FirstOrDefault();
                    result = field;
                    return result;
                }
                return result;
            }
            else return null;
        }

        public DAL.Document GetDocument(string mapCode, int? workItemID)
        {
            return incubatorWorkitemEntitiesManager.GetDocument(mapCode, workItemID);
        }
    }
}
