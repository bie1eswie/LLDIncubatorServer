using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Incubation
{
    public class QuarterMilestone
    {
        public string Description { get; set; }
        public string ShorDescription { get; set; }
        public int QuarterID { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public bool isDirty { get; set; }
        public bool isNew { get; set; }
        public int ID { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;


        public QuarterMilestone()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }
        public QuarterMilestone(DAL.Milestone milestone)
        {
            Description = milestone.Description;
            QuarterID = milestone.QuarterID.Value;
            StartDate = milestone.CreatedDate.Value;
            EndDate = milestone.EndDate.Value.ToString("ddd, MMM d, yyyy"); ;
            ShorDescription = milestone.ShortDescription;
        }

        public bool UpdateSelf()
        {
            bool result = false;
            if (incubatorWorkitemEntitiesManager == null)
                incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            if (isDirty)
                return incubatorWorkitemEntitiesManager.UpdateMileStone(ID, Description, ShorDescription, 1, DateTime.Now, QuarterID);
            else if(isNew)
            {
                return incubatorWorkitemEntitiesManager.AddMileStone(Description, ShorDescription, 1, DateTime.Now, QuarterID);
            }
            return result;
        }
    }
}
