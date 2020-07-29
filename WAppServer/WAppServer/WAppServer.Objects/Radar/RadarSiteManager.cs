using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Radar
{
    public class RadarSiteManager : EntityManager
    {
        public RadarSiteManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
