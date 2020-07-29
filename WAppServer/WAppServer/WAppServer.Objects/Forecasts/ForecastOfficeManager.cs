using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastOfficeManager : EntityManager
    {
        public ForecastOfficeManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
