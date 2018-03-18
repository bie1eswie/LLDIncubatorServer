using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.NET.Services.Abstract;
using Safate.Incubator.API.Core.Helpers;
using Sefate.Incubator.WorkItem.Views;
using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.Incubation;
using System.Web.Http.Cors;
using Safate.Incubator.API.NET.Helpers;

namespace Safate.Incubator.API.NET.Controllers
{
	[Produces("application/json")]
	[Route("api/Incubation")]
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class IncubationController : Controller
	{
		private readonly IIncubationService _incubationService;

		public IncubationController(IIncubationService incubationService)
		{
			this._incubationService = incubationService;
		}

		[Route("requirement")]
		[HttpPost]
		public IActionResult GetIncubationRequirements([FromBody] WorkItemView WorkItemView)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var requirement = _incubationService.GetIncubationRequirement(WorkItemView.WorkItemID);

				if (requirement != null)
				{
					_result = new ObjectResult(requirement);
					return _result;
				}
				else
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = false,
						Message = "Invalid WorkItem."
					};
					_result = new ObjectResult(_requiremtsResult);
					return _result;
				}
			}
			catch (Exception ex)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = ex.Message + "   " +  ex.StackTrace
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
		}

		[Route("updateIncubationRequirement")]
		[HttpPut]
		public IActionResult UpdateIncubationRequirement([FromBody]IncubationRequirement model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.UpdateIncubationRequirement(model);
				if (result.Result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result.Result,
						Message = "Information updated successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}


		[Route("updateComment")]
		[HttpPut]
		public IActionResult UpdateComment([FromBody]WorkItemIncubatorComments model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.UpdateComment(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "Information updated successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}

		[Route("UpdateMilestone")]
		[HttpPut]
		public IActionResult UpdateMilestone([FromBody]QuarterMilestone model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.UpdateMileStone(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "Information updated successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}
		[Route("addMilestone")]
		[HttpPost]
		public IActionResult AddMilestone([FromBody]QuarterMilestone model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.AddMileStone(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "Information updated successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}

		[Route("addCommentt")]
		[HttpPost]
		public IActionResult AddComment([FromBody]WorkItemIncubatorComments model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.AddComment(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "Work item incubator comments added successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}
		[Route("updateQuardrant")]
		[HttpPut]
		public IActionResult UpdateQuardrant([FromBody]IncubatorQuardrant model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.UpdateQuardrant(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "Information updated successfully."
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new GenericResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}

		[Route("addQuarter")]
		[HttpPost]
		public IActionResult AddQuarter([FromBody]QuardrantQuarter model)
		{
			IActionResult _result = new ObjectResult(false);
			AddQuarterResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.AddQuarter(model);
				if (result)
				{
					model = _incubationService.GetQuarterRequirements(model);
					_requiremtsResult = new AddQuarterResult()
					{
						Succeeded = result,
						Message = "Information updated successfully.",
						QuardrantQuarter = model
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new AddQuarterResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}

		[Route("addCommentResponse")]
		[HttpPost]
		public IActionResult AddCommentResponse([FromBody]CommentResponse model)
		{
			IActionResult _result = new ObjectResult(false);
			AddQuarterResult _requiremtsResult = null;

			try
			{
				var result = _incubationService.AddCommentResponse(model);
				if (result)
				{
					_requiremtsResult = new AddQuarterResult()
					{
						Succeeded = result,
						Message = "Information updated successfully.",
					};
					_result = new ObjectResult(_requiremtsResult);
				}

			}
			catch (Exception e)
			{
				_requiremtsResult = new AddQuarterResult()
				{
					Succeeded = false,
					Message = e.Message
				};
				_result = new ObjectResult(_requiremtsResult);
				return _result;
			}
			return new ObjectResult(_requiremtsResult);
		}

        [Route("interventionReportRequirement")]
        [HttpPost]
        public IActionResult GetInterventionReportRequirements([FromBody] IncubationRequirement incubationRequirement)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _requiremtsResult = null;
            try
            {
                var requirement = _incubationService.GetInterventionReportRequirement(incubationRequirement);

                if (requirement != null)
                {
                    _result = new ObjectResult(requirement);
                    return _result;
                }
                else
                {
                    _requiremtsResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid WorkItem."
                    };
                    _result = new ObjectResult(_requiremtsResult);
                    return _result;
                }
            }
            catch (Exception ex)
            {
                _requiremtsResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_requiremtsResult);
                return _result;
            }
        }
    }
}