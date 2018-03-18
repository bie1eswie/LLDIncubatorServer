using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.RequirementsBuilder
{
    public class ClientTypeInfor
    {
        public int ClientTypeID { get; set; }
        public string ClientTypeCode { get; set; }
        public string ClientType { get; set; }

        public ClientTypeInfor(DAL.ClientType clientType)
        {
            this.ClientType = clientType.Type;
            this.ClientTypeCode = clientType.ClientTypeCode;
            this.ClientTypeID = clientType.ClientTypeID;
        }
        public ClientTypeInfor()
        {

        }
    }
}
