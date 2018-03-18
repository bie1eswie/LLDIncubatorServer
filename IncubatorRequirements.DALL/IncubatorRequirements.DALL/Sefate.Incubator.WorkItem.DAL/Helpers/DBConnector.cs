using Sefate.Incubator.WorkItem.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkItem.DAL.Helpers
{
    public class DBConnector
    {
        public static IncubatorClientsEntities Get<T>(bool noChangeTracking = false)
        {
            var t = Activator.CreateInstance(typeof(T), "data source=localhost;initial catalog=IncubatorClients;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
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
            return t as IncubatorClientsEntities;
        }
    }
}
