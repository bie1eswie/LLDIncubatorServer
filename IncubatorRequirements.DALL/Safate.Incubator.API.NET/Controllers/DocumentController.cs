using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safate.Incubator.API.Core.Helpers;
using Sefate.Incubator.WorkItem.Views;
using Sefate.Incubator.WorkItem;
using Safate.Incubator.API.NET.Services.Abstract;
using Sefate.Incubator.Proccess.BLL.Incubation;
using Sefate.Incubator.WorkItem.InterventionReport;
using Microsoft.Net.Http.Headers;

namespace Safate.Incubator.API.NET.Controllers
{
    [Produces("application/json")]
    [Route("api/Document")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }
        [Route("updateStatus")]
        [HttpPut]
        public IActionResult UpdateStatus([FromBody] WorkItemDocument model)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _requiremtsResult = null;

            try
            {
                var result = _documentService.UpdateDocumentStatus(model.DocumentID, model.DocumentStatus.StatusID);
                if (result)
                {
                    //var item = new Sefate.Incubator.WorkItem.WorkItem(model.WorkItemID, false);
                    //NotificationManager.NotificationManager.SendSatusUpdateEmail(item.CreatedBy.Email, "1", model.ToStage, item.CreatedBy.Fullname);
                    _requiremtsResult = new GenericResult()
                    {
                        Succeeded = result,
                        Message = "Document updated successfully."
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

        [Route("generateInterventionReport")]
        [HttpPost]
        public IActionResult GenerateInterventionReport([FromBody] InterventionReport incubationRequirement)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _requiremtsResult = null;
            try
            {
                var _document = _documentService.GenreateInterventionReport(incubationRequirement);
                if (_document != null)
                {
                    HttpContext.Response.ContentType = "application/msword";
                    FileContentResult result = new FileContentResult(_document, "application/msword")
                    {
                        FileDownloadName = incubationRequirement.Client.ClientName+ "_" + "InterventionReport.docx"
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