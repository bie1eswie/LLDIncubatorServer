using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class FieldSetGroupMaps
    {
        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string FieldSetCode { get; set; }
        public string FieldSetName { get; set; }
        public int? FieldSetId { get; set; }
        public string FieldSetGroupCode { get; set; }
        public string FieldSetGroupName { get; set; }
        public int? FieldSetGroupId { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime? LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string FieldSetOrder { get; set; }

        public FieldSets FieldSet { get; set; }
        public FieldSetGroups FieldSetGroup { get; set; }
    }
}
