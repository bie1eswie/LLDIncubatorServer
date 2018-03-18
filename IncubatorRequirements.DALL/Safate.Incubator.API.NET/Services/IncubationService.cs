using Safate.Incubator.API.NET.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Requrements.BLL;
using Sefate.Incubator.WorkItem.Incubation;
using Sefate.Incubator.WorkItem.InterventionReport;

namespace Safate.Incubator.API.NET.Services
{
	public class IncubationService : IIncubationService
	{
		public IncubationRequirement GetIncubationRequirement(int workItemID)
		{
			var requirementManager = new RequirementManager();
			return requirementManager.GetIncubationRequirement(workItemID);
		}

		public UpdateRequirementResult UpdateIncubationRequirement(IncubationRequirement incubationRequirement)
		{
			return incubationRequirement.UpdateSelf(new UpdateRequirementResult());
		}

		public bool AddComment(WorkItemIncubatorComments workItemIncubatorComments)
		{
			return workItemIncubatorComments.UpdateSelf();
		}
		public bool UpdateComment(WorkItemIncubatorComments workItemIncubatorComments)
		{
			return workItemIncubatorComments.UpdateSelf();
		}
		public bool AddMileStone(QuarterMilestone quarterMilestone)
		{
			return quarterMilestone.UpdateSelf();
		}
		public bool UpdateMileStone(QuarterMilestone quarterMilestone)
		{
			return quarterMilestone.UpdateSelf();
		}
		public bool UpdateQuardrant(IncubatorQuardrant incubatorQuardrant)
		{
			UpdateRequirementResult result = new UpdateRequirementResult();
			return incubatorQuardrant.UpdateSelf(ref result).Result;
		}
		public bool AddQuarter(QuardrantQuarter quardrantQuarter)
		{
			UpdateRequirementResult result = new UpdateRequirementResult();
			return quardrantQuarter.UpdateSelf(ref result).Result;
		}

		public QuardrantQuarter GetQuarterRequirements(QuardrantQuarter quardrantQuarter)
		{
			var requirementManager = new RequirementManager();
			quardrantQuarter.SetFieldSetGroups(requirementManager.GetQuarterRequirements(quardrantQuarter.QuardrantID.ToString(), quardrantQuarter.WorkItem, quardrantQuarter.QuarterID));
			return quardrantQuarter;
		}

		public bool AddCommentResponse(CommentResponse res)
		{
			return res.UpdateSelf();
		}

        public InterventionReport GetInterventionReportRequirement(IncubationRequirement incubationRequirement)
        {
            InterventionReport result = null;
            InterventionReportManager interventionReportManager = new InterventionReportManager();
            result = interventionReportManager.GetInterventionRequirement(incubationRequirement);
            return result;
        }

    }
}
