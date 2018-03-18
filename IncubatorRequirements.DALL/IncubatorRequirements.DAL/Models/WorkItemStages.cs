using System;
using System.Collections.Generic;

namespace IncubatorRequirements.DAL.Models
{
    public partial class WorkItemStages
    {
        public int Id { get; set; }
        public Guid? Muid { get; set; }
        public string VersionName { get; set; }
        public int? VersionNumber { get; set; }
        public string VersionFlag { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ChangeTrackingMask { get; set; }
        public string UserCanEditCode { get; set; }
        public string UserCanEditName { get; set; }
        public int? UserCanEditId { get; set; }
        public string NextSageCode { get; set; }
        public string NextSageName { get; set; }
        public int? NextSageId { get; set; }
        public string BussinessCanEditCode { get; set; }
        public string BussinessCanEditName { get; set; }
        public int? BussinessCanEditId { get; set; }
        public DateTime? EnterDateTime { get; set; }
        public string EnterUserName { get; set; }
        public int? EnterVersionNumber { get; set; }
        public DateTime? LastChgDateTime { get; set; }
        public string LastChgUserName { get; set; }
        public int? LastChgVersionNumber { get; set; }
        public string ValidationStatus { get; set; }
        public string HasDocumentsCode { get; set; }
        public string HasDocumentsName { get; set; }
        public int? HasDocumentsId { get; set; }
        public string PreviousStageCode { get; set; }
        public string PreviousStageName { get; set; }
        public int? PreviousStageId { get; set; }
    }
}
