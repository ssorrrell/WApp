using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastTextManager : EntityManager
    {
        public ForecastTextManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
