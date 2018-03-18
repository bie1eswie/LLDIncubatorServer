using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class WorkItemGridView
    {
        public List<WorkItem> WorkItems { get; set; }
        public List<StatusGridView> StatusGridViews { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;
        public WorkItemGridView()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            WorkItems = new List<WorkItem>();
            StatusGridViews = new List<StatusGridView>();
            var dataWorkItems = incubatorWorkitemEntitiesManager.GetAllWorkItems();
            if (dataWorkItems != null)
            {
                foreach (var workIten in dataWorkItems)
                {
                    WorkItem item = new WorkItem(workIten);
                    this.WorkItems.Add(item);
                }
            }

            var itemGroups = WorkItems.GroupBy(x => x.WorkItemStatusInfor.Status);
            int first = 0;
            foreach(var status in itemGroups)
            {
                var item = new StatusGridView();
                if(status!=null)
                {
                    var items = status.ToList();
                    int pageNumber = 1;
                    for(int i = 0; i < items.Count; i = i + 10)
                    {
                        var check = i + 10;
                        var numberOfItems = 10;
                        if(check > items.Count)
                        {
                            numberOfItems = items.Count - i;
                        }
                        var limit = items.GetRange(i, numberOfItems);
                        if(limit!=null && limit.Any())
                        {
                            var page = new StatusGridViewPage();
                            page.WorkItems.AddRange(limit);
                            page.PageNumber = pageNumber;
                            if (i == 0)
                            {
                                page.Active = true;
                                item.CurrentPage = page;
                            }
                            item.StatusGridViewPages.Add(page);
                        }
                        pageNumber++;
                    }
                    item.Status = status.Key;

                    if(first==0)
                    {
                        item.Active = true;
                    }
                    else
                    {
                        item.Active = false;
                    }
                    item.WorkItems.AddRange(items);
                    StatusGridViews.Add(item);
                }
                
                first++;
            }
            string ss = "";
        }
    }
}
