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
    
    public partial class WorkItemIncubationComment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> WorkItemID { get; set; }
        public Nullable<int> PriorityID { get; set; }
        public string ShortDescription { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}
