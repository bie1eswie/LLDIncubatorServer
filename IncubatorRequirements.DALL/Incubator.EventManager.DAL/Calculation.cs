//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Incubator.EventManager.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calculation
    {
        public int ID { get; set; }
        public System.Guid MUID { get; set; }
        public string VersionName { get; set; }
        public int VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ChangeTrackingMask { get; set; }
        public System.DateTime EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public Nullable<int> EnterVersionNumber { get; set; }
        public System.DateTime LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public Nullable<int> LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
    }
}
