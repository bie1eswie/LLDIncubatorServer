//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sefate.Incubator.WorkItem.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class IncubatorEvent
    {
        public int ID { get; set; }
        public Nullable<int> EventType { get; set; }
        public string EventDescription { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
