//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Requirements.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkItemStage
    {
        public int ID { get; set; }
        public Nullable<System.Guid> MUID { get; set; }
        public string VersionName { get; set; }
        public Nullable<int> VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> ChangeTrackingMask { get; set; }
        public string UserCanEdit_Code { get; set; }
        public string UserCanEdit_Name { get; set; }
        public Nullable<int> UserCanEdit_ID { get; set; }
        public string NextSage_Code { get; set; }
        public string NextSage_Name { get; set; }
        public Nullable<int> NextSage_ID { get; set; }
        public string BussinessCanEdit_Code { get; set; }
        public string BussinessCanEdit_Name { get; set; }
        public Nullable<int> BussinessCanEdit_ID { get; set; }
        public Nullable<System.DateTime> EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public Nullable<int> EnterVersionNumber { get; set; }
        public Nullable<System.DateTime> LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public Nullable<int> LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string HasDocuments_Code { get; set; }
        public string HasDocuments_Name { get; set; }
        public Nullable<int> HasDocuments_ID { get; set; }
        public string PreviousStage_Code { get; set; }
        public string PreviousStage_Name { get; set; }
        public Nullable<int> PreviousStage_ID { get; set; }
    }
}
