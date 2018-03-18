using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class DropdownSetMaps
    {
        public int Id { get; set; }
        public Guid Muid { get; set; }
        public string VersionName { get; set; }
        public int VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ChangeTrackingMask { get; set; }
        public string DropdownValueCode { get; set; }
        public string DropdownValueName { get; set; }
        public int? DropdownValueId { get; set; }
        public string DropdownSetCode { get; set; }
        public string DropdownSetName { get; set; }
        public int? DropdownSetId { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime? LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string FieldSetGroupCode { get; set; }
        public string FieldSetGroupName { get; set; }
        public int? FieldSetGroupId { get; set; }
        public string ScoreCard { get; set; }

        public DropdownSets DropdownSet { get; set; }
        public DropdownValues DropdownValue { get; set; }
    }
}
