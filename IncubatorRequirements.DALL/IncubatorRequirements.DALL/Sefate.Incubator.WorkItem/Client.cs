using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem
{
    public class Client
    {
        public string ClientName { get; set; }
        public int ClientType { get; set; }
        public string ClientTypeString { get { return ClientType.ToString(); } set { } }
        public string RegistrationNo { get; set; }
        public string ClientCode { get; set; }
        public int ClientID { get; set; }
        public ClientTypeInfor ClientTypeInfor { get; set; }

        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager;

		public Client()
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
            ClientTypeInfor = new RequirementsBuilder.ClientTypeInfor();
        }

        public Client(string clientName,string registrationNo,int? clientType)
        {
            ClientName = clientName;
            ClientType = clientType.Value;
            RegistrationNo = registrationNo;
            ClientTypeInfor = new RequirementsBuilder.ClientTypeInfor();
        }

        public Client(DAL.Client client)
        {
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			this.ClientCode = "";
            this.ClientID = client.ClientID;
            this.ClientType = client.ClientTypeID.Value;
            this.ClientName = client.ClientName;
            this.RegistrationNo = client.RegistrationNumber;
            if(client.ClientTypeID.HasValue)
            {
                var dbClientType = incubatorWorkitemEntitiesManager.GetClientTypeByID(client.ClientTypeID.Value);
                this.ClientTypeInfor = new ClientTypeInfor(dbClientType);
            }
        }
		public Client(int clientID)
		{
			incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
			var client = incubatorWorkitemEntitiesManager.GetClientByID(clientID);
			this.ClientCode = "";
			this.ClientID = client.ClientID;
			this.ClientType = client.ClientTypeID.Value;
			this.ClientName = client.ClientName;
			this.RegistrationNo = client.RegistrationNumber;
			if (client.ClientTypeID.HasValue)
			{
				var dbClientType = incubatorWorkitemEntitiesManager.GetClientTypeByID(client.ClientTypeID.Value);
				this.ClientTypeInfor = new ClientTypeInfor(dbClientType);
			}
		}

        public ResponseObject CreateClient()
		{
			ResponseObject result = new ResponseObject();
			var client = incubatorWorkitemEntitiesManager.GetClientByRegNo(RegistrationNo);

			if(client!=null)
			{
                result.Error = "Client already exist";
			}
            else
            {
                this.ClientID = incubatorWorkitemEntitiesManager.CreateClient(ClientName, ClientType, RegistrationNo);

                result.Result = ClientID > 0;
            }
            return result;
		}
    }
}
