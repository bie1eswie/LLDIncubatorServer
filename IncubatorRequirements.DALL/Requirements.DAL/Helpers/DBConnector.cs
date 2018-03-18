using Requirements.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncubatorRequirements.DALL.Helpers
{
    public class DBConnector
    {
        public static IncubatorRequirementsContainer Get<T>(bool noChangeTracking = false)
        {
            //string value = "data source=.;initial catalog=IncubatorRequirement;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string value = "Server=tcp:llddatabaseserver.database.windows.net,1433;Initial Catalog=IncubatorRequirement;Persist Security Info=False;User ID=thapelo;Password=banzim12345@gmail.com;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder();
			entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
			entityConnectionStringBuilder.ProviderConnectionString = value;
			entityConnectionStringBuilder.Metadata = "res://*/IncubatorRequirements.csdl|res://*/IncubatorRequirements.ssdl|res://*/IncubatorRequirements.msl";

			var a = entityConnectionStringBuilder.ToString();
			var t = Activator.CreateInstance(typeof(T),a);
            var dbContext = t as DbContext;
            if (t != null)
            {
                var timeoutValue = "60";
                int timeout = 0;
                if (!int.TryParse(timeoutValue, out timeout))
                {
                    timeout = 60;
                }
                // Set the SQL command timeout to the configured timeout value;
                dbContext.Database.CommandTimeout = timeout;

                if (noChangeTracking)
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                }
            }
            return t as IncubatorRequirementsContainer;
        }
    }
}
