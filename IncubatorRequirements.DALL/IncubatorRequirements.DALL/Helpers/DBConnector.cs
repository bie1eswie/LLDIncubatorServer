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
        public static IncubatorEntities Get<T>(bool noChangeTracking = false)
        {
			var entityConnectionStringBuilder = new EntityConnectionStringBuilder();
			entityConnectionStringBuilder.Provider = "System.Data.SqlClient";
			entityConnectionStringBuilder.ProviderConnectionString = "data source=52.234.214.193;initial catalog=Incubator;persist security info=True;user id=thapelo;password=banzim12345@gmail.com;MultipleActiveResultSets=True;App=EntityFramework";
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
            return t as IncubatorEntities;
        }
    }
}
