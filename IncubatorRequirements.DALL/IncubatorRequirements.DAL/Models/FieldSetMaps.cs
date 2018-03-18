using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class FieldSetMaps
    {
        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string FieldCode { get; set; }
        public string FieldName { get; set; }
        public int? FieldId { get; set; }
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
        public string FieldSetCode { get; set; }
        public string FieldSetName { get; set; }
        public int? FieldSetId { get; set; }
        public string ToolTip { get; set; }
        public string FieldOrder { get; set; }
        public string IsRequiredCode { get; set; }
        public string IsRequiredName { get; set; }
        public int? IsRequiredId { get; set; }
        public string CaculationCode { get; set; }
        public string CaculationName { get; set; }
        public int? CaculationId { get; set; }
        public string FieldScore { get; set; }
        public string IsRelatedCode { get; set; }
        public string IsRelatedName { get; set; }
        public int? IsRelatedId { get; set; }
        public string Length { get; set; }

        public ClientFields Field { get; set; }
        public FieldSets FieldSet { get; set; }
    }
}
