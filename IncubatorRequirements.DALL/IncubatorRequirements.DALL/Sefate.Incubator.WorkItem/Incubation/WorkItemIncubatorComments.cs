using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Incubation
{
    public class WorkItemIncubatorComments
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public int WorkItemID { get; set; }
        public string CreatedDateTime { get; set; }
        public bool isDirty { get; set; }
        public bool isNew { get; set; }
        public string ShortDescription { get; set; }
		public UserView CreatedByUser { get; set; }
		public int CreatedBy { get; set; }
		public List<CommentResponse> CommentResponses { get; set; }
		public CommentResponse PlaceHolder { get; set; }
		private AccountManager accountAccess;


		private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

        public WorkItemIncubatorComments()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			CommentResponses = new List<CommentResponse>();
			PlaceHolder = new CommentResponse();
			accountAccess = new AccountManager();
		}

        public WorkItemIncubatorComments(DAL.WorkItemIncubationComment workItemIncubationComment)
        {
			accountAccess = new AccountManager();
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            CommentID = workItemIncubationComment.ID;
            CommentText = workItemIncubationComment.CommentText;
            WorkItemID = workItemIncubationComment.WorkItemID.Value;
            CreatedDateTime = workItemIncubationComment.CreatedDateTime.Value.ToString("ddd, MMM d, yyyy");
			CommentResponses = new List<CommentResponse>();
			PlaceHolder = new CommentResponse();
			var responses = incubatorWorkitemEntitiesManager.GetCommentResponses(CommentID);
            if (responses != null)
            {
                foreach(var res in responses)
                {
                    CommentResponses.Add(new CommentResponse(res));
                }
            }
			if (workItemIncubationComment.CreatedBy.HasValue)
			{
				CreatedBy = workItemIncubationComment.CreatedBy.Value;
				CreatedByUser = accountAccess.GetUser(CreatedBy);
			}
		}

        public bool UpdateSelf()
        {
            bool result = false;
            if (incubatorWorkitemEntitiesManager == null)
                incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            if (isDirty)
                return incubatorWorkitemEntitiesManager.UpdateWorkItemIncubationComment(CommentID, CommentText);
            else if (isNew)
            {
                return incubatorWorkitemEntitiesManager.AddMentorComment(WorkItemID,CommentText, ShortDescription,CreatedByUser.Id);
            }
            return result;
        }
    }
}
