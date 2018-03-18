using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class QuardrantMaps
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
        public string QuadrantCode { get; set; }
        public string QuadrantName { get; set; }
        public int? QuadrantId { get; set; }
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
    }
}
