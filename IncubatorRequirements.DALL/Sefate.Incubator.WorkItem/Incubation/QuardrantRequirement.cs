using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.Proccess.BLL.Incubation
{
    public class QuardrantRequirement
    {
        public int WorkItemID { get; set; }
        public List<IncubatorQuardrant> IncubatorQuardrants { get; set; }

        public QuardrantRequirement()
        {
            IncubatorQuardrants = new List<Incubation.IncubatorQuardrant>();
        }
    }
}
