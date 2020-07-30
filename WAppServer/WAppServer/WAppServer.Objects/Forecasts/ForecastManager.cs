using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastManager : EntityManager
    {
        public ForecastManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
