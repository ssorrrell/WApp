using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.CurrentConditions
{
    public class ObservationSiteManager : EntityManager
    {
        public ObservationSiteManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
