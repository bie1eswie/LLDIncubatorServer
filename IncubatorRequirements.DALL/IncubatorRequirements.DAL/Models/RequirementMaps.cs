using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class RequirementMaps
    {
        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string FieldSetGroupCode { get; set; }
        public string FieldSetGroupName { get; set; }
        public int? FieldSetGroupId { get; set; }
        public string ClientTypeCode { get; set; }
        public string ClientTypeName { get; set; }
        public int? ClientTypeId { get; set; }
        public string WorkItemStatusCode { get; set; }
        public string WorkItemStatusName { get; set; }
        public int? WorkItemStatusId { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime? LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string RequirementsTabCode { get; set; }
        public string RequirementsTabName { get; set; }
        public int? RequirementsTabId { get; set; }
        public string FieldSetGroupOrder { get; set; }

        public ClientTypes ClientType { get; set; }
        public FieldSetGroups FieldSetGroup { get; set; }
        public Requirements RequirementsTab { get; set; }
    }
}
