using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.Incubation;
using Sefate.Incubator.WorkItem.InterventionReport;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safate.Incubator.API.NET.Services.Abstract
{
    public interface IIncubationService
    {
		IncubationRequirement GetIncubationRequirement(int workItemID);
		UpdateRequirementResult UpdateIncubationRequirement(IncubationRequirement incubationRequirement);
		bool AddComment(WorkItemIncubatorComments workItemIncubatorComments);
		bool UpdateComment(WorkItemIncubatorComments workItemIncubatorComments);
		bool AddMileStone(QuarterMilestone quarterMilestone);
		bool UpdateMileStone(QuarterMilestone quarterMilestone);
		bool UpdateQuardrant(IncubatorQuardrant incubatorQuardrant);
		bool AddQuarter(QuardrantQuarter quardrantQuarter);
		QuardrantQuarter GetQuarterRequirements(QuardrantQuarter quardrantQuarter);
		bool AddCommentResponse(CommentResponse res);
        InterventionReport GetInterventionReportRequirement(IncubationRequirement incubationRequirement);

    }
}
