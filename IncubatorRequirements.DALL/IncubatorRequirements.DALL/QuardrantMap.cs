//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IncubatorRequirements.DALL
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuardrantMap
    {
        public int ID { get; set; }
        public System.Guid MUID { get; set; }
        public string VersionName { get; set; }
        public int VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ChangeTrackingMask { get; set; }
        public string FieldSetGroup_Code { get; set; }
        public string FieldSetGroup_Name { get; set; }
        public Nullable<int> FieldSetGroup_ID { get; set; }
        public string Quadrant_Code { get; set; }
        public string Quadrant_Name { get; set; }
        public Nullable<int> Quadrant_ID { get; set; }
        public System.DateTime EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public Nullable<int> EnterVersionNumber { get; set; }
        public System.DateTime LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public Nullable<int> LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string RequirementsTab_Code { get; set; }
        public string RequirementsTab_Name { get; set; }
        public Nullable<int> RequirementsTab_ID { get; set; }
        public string FieldSetGroupOrder { get; set; }
    }
}
