
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkItem.DAL.Helpers;

namespace Sefate.Incubator.WorkItem.DAL
{
    public class IncubatorWorkitemEntitiesManager
    {
        public IncubatorWorkitemEntitiesManager()
        {

        }

        public Document GetDocumentFieldValue(string mapCode)
        {
            Document resut = null;
            using (var currentDataContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentDataContext.Documents
                                where a.FieldMapCode == mapCode
                                select a;
                if (resutList != null && resutList.Any())
                    return resutList.FirstOrDefault();
            }
            return resut;
        }
        #region WorkItemFields
        public bool UpdateField(string FieldValue, int ID,int? quarter)
        {
            bool result = false;

            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fieldList = from a in currentContext.WorkItemFields
                                where a.ID == ID
                                select a;
                if (fieldList != null && fieldList.Any())
                {
                    foreach (var field in fieldList)
                    {
                        field.FieldValue = FieldValue;
						field.WorkItemQuarterID = quarter;
                        var workItemDTO = from a in currentContext.WorkItems
                                          where a.ID == field.WorkItemID
                                          select a;
                        foreach (var item in workItemDTO)
                        {
                            item.ModifiedDate = DateTime.Now;
                        }
                    }
                }
                result = currentContext.SaveChanges() > 0;
            }
            return result;
        }

        public bool AddNewField(int? workItemId, string fieldCode, string fieldValue, string fieldSetCode, string mapCode, string componentRef, bool isRelated, int? quarterID = null)
        {
            bool result = false;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                DAL.WorkItemField dataField = new WorkItemField()
                {
                    ComponentRef = new Guid(),
                    FieldCode = fieldCode,
                    FieldSetCode = fieldSetCode,
                    FieldValue = fieldValue,
                    WorkItemID = workItemId,
                    MapCode = mapCode,
                    WorkItemQuarterID = quarterID,
					IsRelated = isRelated
                };
                currentContext.WorkItemFields.Add(dataField);
                result = currentContext.SaveChanges() > 0;
            }
            return result;
        }

        public List<WorkItemField> GetWorkItemFields(int workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fields = from a in currentContext.WorkItemFields
                             where a.WorkItemID == workItemID
                             select a;
                if (fields != null && fields.Any())
                    return fields.ToList();
                else return null;
            }

        }

        public string GetWorkItemFieldValue(string mapCode, int workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fields = from a in currentContext.WorkItemFields
                             where a.WorkItemID == workItemID && a.MapCode == mapCode
                             select a;
                if (fields != null && fields.Any())
                    return fields.FirstOrDefault().FieldValue;
                else return null;
            }

        }

        public List<WorkItemField> GetQuarterFields(int workItemID, int quarterID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fields = from a in currentContext.WorkItemFields
                             where a.WorkItemID == workItemID && (a.WorkItemQuarterID == quarterID || (a.IsRelated.HasValue && a.IsRelated.Value))
                             select a;
                if (fields != null && fields.Any())
                    return fields.ToList();
                else return null;
            }

        }

        public bool CreateDocument(byte[] content, string mapCode, string fileExt, string documentName, string documentType, int? workItemID)
        {
            bool result = false;
            int? docID = null;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                DAL.Document dataField = new DAL.Document()
                {
                    ComponentRef = new Guid(),
                    DocumentName = documentName,
                    DocumentType = documentType,
                    FieldMapCode = mapCode,
                    WorkItemID = workItemID,
                    Content = content,
                    Extension = fileExt,
                    ContentType = documentType,
                    CreatedDate = DateTime.Now,
                    StatusID = 1,
                    ModifiedDate = DateTime.Now,
                    URL = documentName,
                };
                currentContext.Documents.Add(dataField);
                result = currentContext.SaveChanges() > 0;
                if (result)
                    docID = dataField.ID;
            }

            if (result)
            {
                using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
                {
                    DAL.DocumentStatu dataField = new DAL.DocumentStatu()
                    {
                        DocumentID = docID,
                        StatusID = 1

                    };
                    currentContext.DocumentStatus.Add(dataField);
                    result &= currentContext.SaveChanges() > 0;
                }
            }
            return result;
        }

        public Document GetDocument(string mapCode, int? workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fields = from a in currentContext.Documents
                             where a.WorkItemID == workItemID && a.FieldMapCode == mapCode
                             select a;
                if (fields != null && fields.Any())
                    return fields.FirstOrDefault();
                else return null;
            }
        }

        public Document GetDocument(int documentID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fields = from a in currentContext.Documents
                             where a.ID == documentID
                             select a;
                if (fields != null && fields.Any())
                    return fields.FirstOrDefault();
                else return null;
            }
        }

        public bool UpdateDocument(byte[] content, string mapCode, string fileExt, string documentName, string documentType, int? workItemID, int documentID)
        {
            bool result = false;

            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var fieldList = from a in currentContext.Documents
                                where a.ID == documentID
                                select a;
                if (fieldList != null && fieldList.Any())
                {
                    foreach (var field in fieldList)
                    {
                        field.DocumentName = documentName;
                        field.Content = content;
                        field.DocumentType = documentType;
                        field.Extension = fileExt;
                    }
                }
                result = currentContext.SaveChanges() > 0;
            }
            return result;
        }

        public bool UpdateDocumentStatus(int status, int documentID)
        {
            bool result = false;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var docList = from a in currentContext.DocumentStatus
                              where a.DocumentID == documentID
                              select a;

                if (docList != null && docList.Any())
                {
                    foreach (var doc in docList)
                    {
                        doc.StatusID = status;
                    }
                }
                result = currentContext.SaveChanges() > 0;
            }

            if (result)
            {
                using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
                {
                    var docList = from a in currentContext.Documents
                                  where a.ID == documentID
                                  select a;

                    if (docList != null && docList.Any())
                    {
                        foreach (var doc in docList)
                        {
                            doc.StatusID = status;
                        }
                    }
                    result &= currentContext.SaveChanges() > 0;
                }
            }
            return result;
        }

        #endregion

        #region WorkItem
        public int CreateWorkItem(int status, int clientID, int user)
        {
            int result = 0;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var workItem = new WorkItem()
                {
                    ClientID = clientID,
                    StatusID = status,
                    ModifiedBy = user.ToString(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = user.ToString(),
                    IsChecked = false,
                };
                currentContext.WorkItems.Add(workItem);
                currentContext.SaveChanges();
                result = workItem.ID;
            }

            if (result > 0)
            {
                using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
                {
                    var relation = new CompanyUser()
                    {
                        ClientID = clientID,
                        UserID = user
                    };
                    currentContext.CompanyUsers.Add(relation);
                    currentContext.SaveChanges();
                    int id = relation.CompanyUserID;
                    if (id == 0)
                        throw new Exception("Could not creat e relationship");

                    //result = relation.ID;
                }
            }
            return result;
        }

        public bool CreateIdentityFields(int workItem, string name, string email, string registrationNo)
        {
            bool result = true;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemField clientName = new WorkItemField()
                {
                    FieldCode = "1",
                    FieldSetCode = "2",
                    WorkItemID = workItem,
                    FieldValue = name,
                    MapCode = "1"
                };
                currentContext.WorkItemFields.Add(clientName);
                result &= currentContext.SaveChanges() > 0;
            }

            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemField clientemail = new WorkItemField()
                {
                    FieldCode = "10",
                    FieldSetCode = "2",
                    WorkItemID = workItem,
                    FieldValue = email,
                    MapCode = "3"
                };
                currentContext.WorkItemFields.Add(clientemail);
                result &= currentContext.SaveChanges() > 0;
            }

            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemField clientRegNo = new WorkItemField()
                {
                    FieldCode = "2",
                    FieldSetCode = "1",
                    WorkItemID = workItem,
                    FieldValue = registrationNo,
                    MapCode = "2"
                };

                var workItemDTO = from a in currentContext.WorkItems
                                  where a.ID == workItem
                                  select a;
                foreach (var item in workItemDTO)
                {
                    item.ModifiedDate = DateTime.Now;
                }
                currentContext.WorkItemFields.Add(clientRegNo);
                result &= currentContext.SaveChanges() > 0;
            }

            return result;
        }

        public WorkItem GetWorkItemByClient(int clientID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItems
                                where a.ClientID == clientID
                                select a;
                return resutList.FirstOrDefault();
            }
        }

        public WorkItem GetWorkItemByID(int workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItems
                                where a.ID == workItemID
                                select a;
                return resutList.FirstOrDefault();
            }
        }

        public WorkItemStage GetWorkItemStatus(int workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItemStages
                                where a.WorkItemID == workItemID
                                select a;
                return resutList.FirstOrDefault();
            }
        }

        public Stage GetItemStage(int stage)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.Stages
                                where a.StageID == stage
                                select a;
                return resutList.FirstOrDefault();
            }
        }

        public bool AddItemStage(int worditem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemStage stage = new WorkItemStage()
                {
                    StageID = 1,
                    WorkItemID = worditem,
                };
                currentContext.WorkItemStages.Add(stage);
                return currentContext.SaveChanges() > 0;
            }
        }

        public bool AddItemWorkItemTimeLines(int worditem, int worditemStage, int user, bool isIncubation = false)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemTimeLine stage = new WorkItemTimeLine()
                {
                    CreatedDate = DateTime.Now,
                    WorkItemID = worditem,
                    IncubationStageID = null,
                    WorkItemStageID = worditemStage,
                    CreatedBy = user
                };

                if (isIncubation)
                {
                    stage.IncubationStageID = worditemStage;
                }
                currentContext.WorkItemTimeLines.Add(stage);
                return currentContext.SaveChanges() > 0;
            }
        }

        public WorkItemDocumentStatu GetWorkItemDocumentStatus(int workItemID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItemDocumentStatus
                                where a.WorkItemID == workItemID
                                select a;
                return resutList.FirstOrDefault();
            }
        }

        public bool GetWorkItemDocumentStatus(int workItemID, int statusID)
        {
            bool result = false;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItemDocumentStatus
                                where a.WorkItemID == workItemID
                                select a;
                if (resutList != null)
                {
                    foreach (var status in resutList)
                    {
                        status.StatusID = statusID;
                    }
                }
                result = currentContext.SaveChanges() > 0;
            }
            return result;
        }

        public List<WorkItem> GetAllWorkItems()
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var resutList = from a in currentContext.WorkItems
                                where a.ClientID != null
                                orderby a.CreatedDate descending
                                select a;

                if (resutList != null)
                    return resutList.ToList();
                else return null;
            }
        }
        #endregion

        #region Client
        public int CreateClient(string clientName, int clientType, string reqistrationNo)
        {
            int result = 0;
            using (var currentContext = new IncubatorClientsEntities())
            {
                var client = new Client()
                {
                    ClientName = clientName,
                    ClientTypeID = clientType,
                    RegistrationNumber = reqistrationNo
                };
                currentContext.Clients.Add(client);
                currentContext.SaveChanges();
                result = client.ClientID;
            }
            return result;
        }

        public Client GetClientByRegNo(string registrationNo)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = from a in currentContext.Clients
                                 where a.RegistrationNumber == registrationNo
                                 select a;
                if (clientList != null)
                    return clientList.FirstOrDefault();
            }
            return null;
        }

        public Client GetClientByID(int clientID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = from a in currentContext.Clients
                                 where a.ClientID == clientID
                                 select a;
                if (clientList != null)
                    return clientList.FirstOrDefault();
            }
            return null;
        }

        public ClientType GetClientTypeByID(int clientType)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = from a in currentContext.ClientTypes
                                 where a.ClientTypeID == clientType
                                 select a;
                if (clientList != null)
                    return clientList.FirstOrDefault();
            }
            return null;
        }

        public List<WorkItemTimeLine> GetWorkItemTimeLine(int workItem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = from a in currentContext.WorkItemTimeLines
                                 where a.WorkItemID == workItem
                                 select a;
                if (clientList != null)
                    return clientList.ToList();
            }
            return null;
        }

        public List<WorkItemIncubationComment> GetWorkItemComments(int workItem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = (from a in currentContext.WorkItemIncubationComments
                                  where a.WorkItemID == workItem
                                  orderby a.CreatedDateTime descending
                                  select a).Take(10);
                if (clientList != null)
                    return clientList.ToList();
            }
            return null;
        }

        public List<CommentRecomendation> GetCommentResponses(int commentID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var clientList = (from a in currentContext.CommentRecomendations
								  where a.CommentID == commentID
                                  orderby a.CreatedDate
                                  select a).Take(10);
                if (clientList != null)
                    return clientList.ToList();
                else return null;
            }
        }

        public bool AddCommentResponse(string response, int commentID, int user)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                CommentRecomendation res = new DAL.CommentRecomendation()
                {
                    CommentID = commentID,
                    CreatedBy = user,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Response = response
                };
                currentContext.CommentRecomendations.Add(res);
                return currentContext.SaveChanges() > 0;
            }
        }


        #endregion

        #region WorkFlow

        public List<Stage> GetStages()
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.Stages
                            select a;
                if (items != null)
                    return items.ToList();
                return null;
            }
        }
        public WorkItemStage GetWorkItemStage(int workItem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var item = from a in currentContext.WorkItemStages
                           where a.WorkItemID == workItem
                           select a;
                if (item != null)
                    return item.FirstOrDefault();
                return null;
            }
        }
        public WorkItemStage GetWorkItemStageByStageID(int stageId)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var item = from a in currentContext.WorkItemStages
                           where a.StageID == stageId
                           select a;
                if (item != null)
                    return item.FirstOrDefault();
                return null;
            }
        }

        public WorkItemStage GetStageCode(string stageCode)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var item = from a in currentContext.Stages
                           where a.StageCode == stageCode
                           select a;
                if (item != null)
                {
                    var stage = item.FirstOrDefault();
                    if (stage != null)
                    {
                        var workItemStage = from a in currentContext.WorkItemStages
                                            where a.StageID == stage.StageID
                                            select a;
                        if (workItemStage != null)
                            return workItemStage.FirstOrDefault();
                    }
                }
                //return 
                return null;
            }
        }

        public bool UpdateWorkitemViewStatus(int workitem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.WorkItems
                            where a.ID == workitem
                            select a;

                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        item.IsChecked = !item.IsChecked;
                    }
                }
                return currentContext.SaveChanges() > 0;
            }
        }

        public Stage GetStageByCode(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var stage = from a in currentContext.Stages
                            where a.StageCode == code
                            select a;
                if (stage != null)
                    return stage.First();
                return null;
            }
        }

        public bool UpdateWorkItemStage(string nextCode, int workItemID, int user)
        {
            bool result = false;
            int stage = 0;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var item = from a in currentContext.WorkItemStages
                           where a.WorkItemID == workItemID
                           select a;

                if (item != null)
                {
                    var next = GetStageByCode(nextCode);

                    foreach (var work in item)
                    {
                        work.StageID = next.StageID;
                        stage = next.StageID;
                    }
                }

                var workItem = from a in currentContext.WorkItems
                               where a.ID == workItemID
                               select a;
                foreach (var work in workItem)
                {
                    work.ModifiedDate = DateTime.Now;
                    work.ModifiedBy = user.ToString();
                }
                result = currentContext.SaveChanges() > 0;
            }
            if (result)
            {
                result &= AddItemWorkItemTimeLines(workItemID, stage, user);
            }
            return result;
        }

        public DocumentReviewStatu DocumentStatus(int statusID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var stage = from a in currentContext.DocumentReviewStatus
                            where a.ID == statusID
                            select a;
                if (stage != null)
                    return stage.First();
                return null;
            }
        }

        #endregion

        #region Documents
        public DocumentStatu GetDocumentStatus(int documentID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.DocumentStatus
                            where a.DocumentID == documentID
                            select a;
                if (items != null)
                    return items.FirstOrDefault();
                return null;
            }
        }

        public List<Document> GetWorkItemDocumet(int workitem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.Documents
                            where a.WorkItemID == workitem
                            select a;
                if (items != null)
                    return items.ToList();
                return null;
            }
        }
        #endregion

        #region Incubation
        public IncubatorQuardrant GetIncubatorQuardrantByCode(string Code)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.IncubatorQuardrants
                            where a.IncubatorQuardrantCode == Code
                            select a;
                if (items != null)
                    return items.FirstOrDefault();
                return null;
            }
        }

        public List<IncubatorQuarter> GetIncubatorQuardrantQuarters(int IncubatorQuardrantID, int workItem)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.IncubatorQuarters
                            where a.IncubatorQuardrantID == IncubatorQuardrantID && a.WorkItemID == workItem
                            select a;
                if (items != null)
                    return items.ToList();
                return null;
            }
        }

        public int AddQuardrantQuarter(string name, int workItem, int quardrant)
        {
            int result = 0;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                IncubatorQuarter item = new IncubatorQuarter()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Quarder = name,
                    WorkItemID = workItem,
                    IncubatorQuardrantID = quardrant
                };
                currentContext.IncubatorQuarters.Add(item);
                currentContext.SaveChanges();
                result = item.IncubatorQuarterID;
            }
            return result;
        }

        public bool AddMentorComment(int worditem, string comment, string shortDescription,int user)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemIncubationComment stage = new WorkItemIncubationComment()
                {
                    CommentText = comment,
                    CreatedDateTime = DateTime.Now,
                    WorkItemID = worditem,
                    ShortDescription = shortDescription,
					CreatedBy = user
                };
                currentContext.WorkItemIncubationComments.Add(stage);
                return currentContext.SaveChanges() > 0;
            }
        }

        public bool AddWorkItemIncubationStage(int worditem, int stageID, int user)
        {
            bool result = false;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                WorkItemIncubationStage stage = new WorkItemIncubationStage()
                {
                    CreatedDate = DateTime.Now,
                    IncubationSageID = stageID,
                    WorkItemID = worditem,
                    ModifiedDate = DateTime.Now
                };
                currentContext.WorkItemIncubationStages.Add(stage);
                result = currentContext.SaveChanges() > 0;
            }
            if (result)
            {
                result &= AddItemWorkItemTimeLines(worditem, stageID, user, true);
            }
            return result;
        }

        public bool UpdateWorkItemIncubationStage(int workItemIncubationSageID, int stageID, int workitem, int user)
        {
            bool result = false;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.WorkItemIncubationStages
                            where a.ID == workItemIncubationSageID
                            select a;

                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        item.IncubationSageID = stageID;
                        item.ModifiedDate = DateTime.Now;
                    }
                }
                result = currentContext.SaveChanges() > 0;
            }
            if (result)
            {
                result &= AddItemWorkItemTimeLines(workitem, stageID, user, true);
            }
            return result;
        }

        public bool UpdateWorkItemIncubationComment(int workItemIncubationCommentID, string comment)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.WorkItemIncubationComments
                            where a.ID == workItemIncubationCommentID
                            select a;

                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        item.CommentText = comment;
                        item.CreatedDateTime = DateTime.Now;
                    }
                }
                return currentContext.SaveChanges() > 0;
            }
        }
        public List<Milestone> GetIncubatorQuarterMileStones(int IncubatorQuardrantID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.Milestones
                            where a.QuarterID == IncubatorQuardrantID
                            select a;
                if (items != null)
                    return items.ToList();
                return null;
            }
        }

        public bool AddMileStone(string description, string shortDescription, int workItemID, DateTime endDate, int quarter)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                Milestone milestone = new DAL.Milestone()
                {
                    CreatedDate = DateTime.Now,
                    Description = description,
                    ShortDescription = shortDescription,
                    EndDate = endDate,
                    QuarterID = quarter
                };
                currentContext.Milestones.Add(milestone);
                return currentContext.SaveChanges() > 0;
            }
        }

        public bool UpdateMileStone(int milestone, string description, string shortDescription, int workItemID, DateTime endDate, int quarter)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.Milestones
                            where a.ID == milestone
                            select a;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        item.Description = description;
                        item.ShortDescription = shortDescription;
                    }
                }
                return currentContext.SaveChanges() > 0;
            }
        }
        public IncubationStage GetWorkItemIncubationStage(int stageID)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.IncubationStages
                            where a.IncubationStageID == stageID
                            select a;

                if (items != null)
                    return items.FirstOrDefault();
                return null;
            }
        }

        public List<WorkItemIncubationStage> MostRecentWorkItemIncubationStage(int limit, DateTime date)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = (from a in currentContext.WorkItemIncubationStages
                             where a.ModifiedDate < date
                             orderby a.ModifiedDate descending
                             select a).Take(limit);

                if (items != null)
                    return items.ToList();
                return null;
            }
        }
        #endregion

        #region Incubator Events

        public int AddEvent(string descreption, int type, DateTime startDate, DateTime endDate)
        {
            int result = 0;
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var item = new IncubatorEvent()
                {
                    EventDescription = descreption,
                    EventType = type,
                    CreatedDate = DateTime.Now,
                    EndDate = endDate,
                    StartDate = startDate


                };

                return result;
            }
        }

        public IncubatorEvent GetIncubatorEvent(int id)
        {
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.IncubatorEvents
                            where a.ID == id
                            select a;

                if (items != null && items.Any())
                    return items.FirstOrDefault();
                else return null;
            }
        }
        public List<IncubatorEvent> GetIncubatorEvents(int client)
        {
            List<IncubatorEvent> result = new List<IncubatorEvent>();
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.EventInvitations
                            where a.ClientID == client
                            select a;

                foreach (var item in items)
                {
                    var eventData = (from a in currentContext.IncubatorEvents
                                     where a.ID == item.EventID
                                     select a).ToList();
                    if (eventData != null && eventData.Any())
                        result.AddRange(eventData);
                }
                return result;
            }
        }

        public List<EventInvitation> GetEventInvitation(int eventID)
        {
            List<EventInvitation> result = new List<DAL.EventInvitation>();
            using (var currentContext = DBConnector.Get<IncubatorClientsEntities>())
            {
                var items = from a in currentContext.EventInvitations
                            where a.EventID == eventID
                            select a;

                if (items != null && items.Any())
                    return items.ToList();
                else return null;
            }
        }

        // public List<Eventg>
        #endregion
    }
}
