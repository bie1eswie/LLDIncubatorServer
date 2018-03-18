using Sefate.Incubator.UserAccess.BLL;
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.Incubation
{
    public class CommentResponse
    {
        public int CommentID { get; set; }
        public string Response { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserView CreatedByUser { get; set; }
        public int CreatedBy { get; set; }
        public bool isDirty { get; set; }
        public bool isNew { get; set; }
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        private AccountManager accountAccess;
        public CommentResponse()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            accountAccess = new AccountManager();
        }
        public bool UpdateSelf()
        {
            if (incubatorWorkitemEntitiesManager == null)
                incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            //if (isDirty)
                return incubatorWorkitemEntitiesManager.AddCommentResponse(Response,CommentID, CreatedByUser.Id);
        }

        public CommentResponse(DAL.CommentRecomendation res)
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            accountAccess = new AccountManager();
            if (res != null)
            {
                Response = res.Response;
                CreatedBy = res.CreatedBy.Value;
                CommentID = res.CommentID.Value;
                CreatedByUser = accountAccess.GetUser(CreatedBy);       
            }
        }
    }
}
