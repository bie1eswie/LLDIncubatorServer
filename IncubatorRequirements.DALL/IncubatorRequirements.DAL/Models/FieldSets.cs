using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class FieldSets
    {
        public FieldSets()
        {
            FieldSetGroupMaps = new HashSet<FieldSetGroupMaps>();
            FieldSetMaps = new HashSet<FieldSetMaps>();
        }

        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string Description { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime? LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string PrePopulateCode { get; set; }
        public string PrePopulateName { get; set; }
        public int? PrePopulateId { get; set; }
        public string IsCalculatedCode { get; set; }
        public string IsCalculatedName { get; set; }
        public int? IsCalculatedId { get; set; }
        public string IsHiddenCode { get; set; }
        public string IsHiddenName { get; set; }
        public int? IsHiddenId { get; set; }

        public ICollection<FieldSetGroupMaps> FieldSetGroupMaps { get; set; }
        public ICollection<FieldSetMaps> FieldSetMaps { get; set; }
    }
}
