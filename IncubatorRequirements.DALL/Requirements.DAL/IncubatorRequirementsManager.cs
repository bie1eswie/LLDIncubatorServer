using IncubatorRequirements.DALL;
using IncubatorRequirements.DALL.Helpers;
using Requirements.DAL;
using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncubatorRequirements.DAL
{
    public class IncubatorRequirementsManager
    {
        private IncubatorRequirementsContainer dataContext = null;
        public IncubatorRequirementsContainer DataContext
        {
            get
            {
                return dataContext;
            }
            set
            {
                dataContext = value;
            }
        }

        public IncubatorRequirementsManager()
        {
            dataContext = new IncubatorRequirementsContainer();
        }

        public IncubatorRequirementsManager(IncubatorRequirementsContainer dataContext)
        {
            DataContext = dataContext;
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public List<RequirementMap> GetRequirementMapping(string statusCode, string clientTyype)
        {
			List<String> prev = new List<string>();

			int current = 0;
			if (Int32.TryParse(statusCode, out current))
			{
				for (int i = current; i >= 1; i--)
				{
					prev.Add(i.ToString());
				}
			}
            List<RequirementMap> result = new List<RequirementMap>();
            using (var currentDataContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var requirements = (from a in currentDataContext.RequirementMaps
                                    where (a.ClientType_Code == clientTyype || a.ClientType_Code == "*") &&( a.WorkItemStatus_Code == statusCode || prev.Contains(a.WorkItemStatus_Code))
                                    select a);
                if (requirements != null)
                    return requirements.ToList();
                else return null;
            }
        }

        public List<QuardrantMap> GetRequirementMapping(string quardrantCode)
        {
            List<RequirementMap> result = new List<RequirementMap>();
            using (var currentDataContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var requirements = (from a in currentDataContext.QuardrantMaps
                                    where (a.Quadrant_Code == quardrantCode || a.Quadrant_Code =="*")
                                    select a);
                if (requirements != null)
                    return requirements.ToList();
                else return null;
            }
        }

        public List<Requirements.DAL.IncubatorQuardrant> IncubatorQuardrants()
        {
            using (var currentDataContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var requirements = (from a in currentDataContext.IncubatorQuardrants
                                    select a);
                if (requirements != null)
                    return requirements.ToList();
                else return null;
            }
        }


        public DropdownSet GetDropdownSet(string code)
        {
            DropdownSet result = new DropdownSet();
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var dropDownSet = from a in currentContext.DropdownSets
                                  where a.Code == code
                                  select a;
                if (dropDownSet != null && dropDownSet.Any())
                {
                    result = dropDownSet.FirstOrDefault();
                }
            }


            return result;
        }

        public FieldSetGroup GetFieldSetGroupByCode(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.FieldSetGroups
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.FirstOrDefault();
            }
            return null;
        }

        public List<FieldSetGroupMap> FieldSetGroupMaps(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.FieldSetGroupMaps
                                     where a.FieldSetGroup_Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }
        public List<FieldSetMap> FieldSetMaps(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.FieldSetMaps
                                     where a.FieldSet_Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }

        public FieldSet FieldSet(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.FieldSets
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null && fieldSetGroups.Any())
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }

        }

        public ClientField ClientField(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.ClientFields
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null && fieldSetGroups.Any())
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }

        }

        public Calculation GetCalculation(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.Calculations
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null && fieldSetGroups.Any())
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }
        }

        public FieldSetMap GetFieldSetMap(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.FieldSetMaps
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null && fieldSetGroups.Any())
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }
        }

        public List<CalculationMap> GetCalculationMaps(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.CalculationMaps
                                     where a.Caculation_Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }

        public List<DropdownSetMap> DropdownSetMap(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.DropdownSetMaps
                                     where a.DropdownSet_Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }

        public List<Requirements.DAL.WorkItemStage> GetWorkItemStages()
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.WorkItemStages
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }

        public Requirements.DAL.WorkItemStage GetWorkItemStageByCode(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.WorkItemStages
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }
        }

        public List<WorkItemStageMap> GetWorkItemStageMapsByCode(string code,string teamCode)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.WorkItemStageMaps
                                     where a.WorkItemStage_Code == code && a.ActionTeam_Code == teamCode
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.ToList();
                else return null;
            }
        }

        public Requirements.DAL.WorkItemStage GetWorkItemStage(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var fieldSetGroups = from a in currentContext.WorkItemStages
                                     where a.Code == code
                                     select a;
                if (fieldSetGroups != null)
                    return fieldSetGroups.FirstOrDefault();
                else return null;
            }
        }

        #region Common
        public RejectionReason RejectionReason(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var rejectionReason = from a in currentContext.RejectionReasons
                                     where a.Code == code
                                     select a;
                if (rejectionReason != null)
                    return rejectionReason.FirstOrDefault();
                else return null;
            }
        }

        public List<WorkItemStageReason> WorkItemStageReasons(string code)
        {
            using (var currentContext = DBConnector.Get<IncubatorRequirementsContainer>())
            {
                var workItemStageReasons = from a in currentContext.WorkItemStageReasons
                                      where a.Stage_Code == code
                                      select a;
                if (workItemStageReasons != null)
                    return workItemStageReasons.ToList();
                else return null;
            }
        }
        #endregion
    }
}
