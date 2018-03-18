using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.NET.Services.Abstract;
using Sefate.Incubator.WorkItem.Views;
using Safate.Incubator.API.Core.Helpers;
using System.Web.Http.Cors;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using System.IO;
using Safate.Incubator.API.NET.Helpers;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Sefate.Incubator.WorkItem;
using Safate.Incubator.API.NET.ViewModels.Notification;

namespace Safate.Incubator.API.NET.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class WorkItemController : Controller
	{
		private readonly IWorkItemService _workItemServive;

		private readonly IDocumentService _documentService;

		public WorkItemController(IWorkItemService workItemServive, IDocumentService documentService)
		{
			this._workItemServive = workItemServive;
			this._documentService = documentService;
		}

		[Route("requirement")]
		[HttpPost]
		public IActionResult GetWorkItemRequirements([FromBody] WorkItemView WorkItemView)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var requirement = _workItemServive.GetWorkItemRequirements(WorkItemView.PrimaryClient.ClientTypeString, WorkItemView.WorkItemStatusInfor.StatusCode, WorkItemView.CurrentRole.ToString(), WorkItemView.WorkItemID);

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
		[Route("updateWorkItemRequirements")]
		[HttpPut]
		public IActionResult UpdateWorkItemRequirements([FromBody]WorkItemRequirements model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _workItemServive.UpdateWorkItemRequirements(model);
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

		[Route("updateWorkItemStatus")]
		[HttpPut]
		public IActionResult UpdateWorkItemStatus([FromBody]WorkItemView model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _workItemServive.UpdateWorkItemStatus(model);
				if (result)
				{

					
				}
				_requiremtsResult = new GenericResult()
				{
					Succeeded = result,
					Message = "Invalid WorkItem."
				};
				_result = new ObjectResult(_requiremtsResult);

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

		[Route("updateStatus")]
		[HttpPut]
		public IActionResult UpdateStatus([FromBody] StageUpdateView model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _workItemServive.UpdateStatus(model);
				if (result)
				{
					var item = new Sefate.Incubator.WorkItem.WorkItem(model.WorkItemID, 0);
					var updateView = new StatusUpdateView(Int32.Parse(model.ToStage), item.PrimaryClient.ClientName, model.FromStage, item.CreatedBy.Email);
					if (model.isReject)
					{
						NotificationManager.NotificationManager.SendSatusUpdateRejectionEmail(updateView.UserEmail, updateView.FromStatus, updateView.ToStatus, updateView.ClientName, model.Reason,model.comment);
					}
					else if(model.ToStage.Trim() != "4".Trim()) {
						NotificationManager.NotificationManager.SendSatusUpdateEmail(updateView.UserEmail, updateView.FromStatus, updateView.ToStatus, updateView.ClientName);
					}


					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "WorkItem updated successfully."
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

		[Route("submit")]
		[HttpPut]
		public IActionResult Submit([FromBody] StageUpdateView model)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;

			try
			{
				var result = _workItemServive.UpdateStatus(model);
				if (result)
				{
					_requiremtsResult = new GenericResult()
					{
						Succeeded = result,
						Message = "WorkItem submitted successfully."
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

		[Route("uploadDocument")]
		[HttpPost]
		public IActionResult Upload(IFormCollection file)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				if (file != null && file.Any())
				{
					var fieldJson = file.FirstOrDefault().Value;
					WorkItemField field = JsonConvert.DeserializeObject<WorkItemField>(fieldJson);
					if (file.Files == null) throw new Exception("File is null");
					if (file.Files[0].Length == 0) throw new Exception("File is empty");

					var fileContentMete = file.Files[0];
					byte[] fileContent = null;
					using (Stream stream = fileContentMete.OpenReadStream())
					{
						using (var binaryReader = new BinaryReader(stream))
						{
							fileContent = binaryReader.ReadBytes((int)fileContentMete.Length);
							//await _uploadService.AddFile(fileContent, file.FileName, file.ContentType);
						}
					}

					if (fileContent != null)
					{
						field.FieldTypeEnum = FieldTypeEnum.DocumentUploadField;
						UpdateRequirementResult updateResult = new UpdateRequirementResult();
						field.WorkItemDocument = WorkItemField.CreateDocumentContent(fileContent, field.MapCode, fileContentMete.FileName, fileContentMete.FileName, fileContentMete.ContentType);
						field.UpdateSelf(ref updateResult);

						if (updateResult.Result)
						{
							_requiremtsResult = new GenericResult()
							{
								Succeeded = updateResult.Result,
								Message = "Invalid WorkItem."
							};
							_result = new ObjectResult(_requiremtsResult);
							return _result;
						}
						else
						{
							_requiremtsResult = new GenericResult()
							{
								Succeeded = updateResult.Result,
								Message = "Invalid WorkItem."
							};
							_result = new ObjectResult(_requiremtsResult);
							return _result;
						}
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
		[Route("downloadDocument")]
		[HttpGet]
		public IActionResult download([FromBody] WorkItemDocument file)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var _document = _documentService.GetDocument(file.DocumentID);
				if (_document != null)
				{
					HttpContext.Response.ContentType = _document.ContentType;
					FileContentResult result = new FileContentResult(_document.DocumentContent, _document.ContentType)
					{
						FileDownloadName = _document.DocumentName
					};

					_result = new ObjectResult(result);
					return _result;
				}
				else
				{
					throw new Exception("Document not found");
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
		[Route("workItems")]
		[HttpGet]
		public IActionResult WorkItems()
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var requirement = _workItemServive.GetAllWorkItems();

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
						Message = "No workItems found."
					};
					_result = new ObjectResult(_requiremtsResult);
					return _result;
				}
			}
			catch(Exception ex)
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

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			IActionResult _result = new ObjectResult(false);
			GenericResult _requiremtsResult = null;
			try
			{
				var _document = _documentService.GetDocument(id);
				if (_document != null)
				{
					HttpContext.Response.ContentType = _document.ContentType;
					FileContentResult result = new FileContentResult(_document.DocumentContent, _document.ContentType)
					{
						FileDownloadName = _document.DocumentName
					};

					//_result = new ObjectResult(result);
					return result;
				}
				else
				{
					throw new Exception("Document not found");
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