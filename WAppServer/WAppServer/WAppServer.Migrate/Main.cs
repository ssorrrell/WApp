using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using WAppServer.Objects;

namespace WAppServer.Migrate
{
    public class Main
    {
        public Main()
        {
        }

        public int CreateDatabase()
        {
            //Create Tables for an Empty Database
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString: Objects.DBConnection.DB.ConnectionString))
            {
                //ActivityLog
                var activityLog = new ActivityLog();
                var sql = activityLog.CreateTable();
                SqlCommand command = new SqlCommand(sql, connection);
                result = command.ExecuteNonQuery();
                //ObservationSites
                //CurrentConditions
                //ForecastOffices
                //Forecasts
                //ForecastDetails
                //ForecastText
                //RadarSites
                //RadarFiles
            }
            return result;
        }

        public int UpToVersionX()
        {
            //Placeholder for Migration from one Version to Another
            throw new NotImplementedException();
        }
    }
}
