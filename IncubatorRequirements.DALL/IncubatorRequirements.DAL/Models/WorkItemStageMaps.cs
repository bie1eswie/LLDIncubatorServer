using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class WorkItemStageMaps
    {
        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string ActionTeamCode { get; set; }
        public string ActionTeamName { get; set; }
        public int? ActionTeamId { get; set; }
        public string WorkItemStageCode { get; set; }
        public string WorkItemStageName { get; set; }
        public int? WorkItemStageId { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
    }
}
