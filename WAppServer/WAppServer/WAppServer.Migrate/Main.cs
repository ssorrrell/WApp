using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Migrate.StaticData;
using WAppServer.Objects.DBConnection;
using WAppServer.Objects.Models;

namespace WAppServer.Migrate
{
    public class Main
    {
        private ActivityLog _log = ActivityLog.Instance;

        public Main()
        {
        }

        public void RunUp()
        {
            try
            {
                CreateDatabase();
                var loadStaticData = new LoadStaticData();
                loadStaticData.RadarSites();
                loadStaticData.ForecastOffices();
                loadStaticData.ObservationSites();
            }
            catch(Exception ex)
            {
                _log.Fatal(ex);
            }
        }

        private int UpToVersionX()
        {
            //Placeholder for Migration from one Version to Another
            throw new NotImplementedException();
        }

        private int CreateDatabase()
        {
            //Create Tables for an Empty Database
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString: DB.ConnectionString))
            {
                //CurrentConditions
                var currentConditions = new CurrentConditions();
                result = ExecuteCommand(connection, currentConditions);

                //ObservationSites
                var observationSites = new ObservationSites();
                result = ExecuteCommand(connection, observationSites);

                //ForecastOffices
                var forecastOffices = new ForecastOffices();
                result = ExecuteCommand(connection, forecastOffices);

                //ForecastDetails
                var forecastDetails = new ForecastDetails();
                result = ExecuteCommand(connection, forecastDetails);

                //ForecastText
                var forecastText = new ForecastText();
                result = ExecuteCommand(connection, forecastText);

                //Forecasts
                var forecast = new ForecastOffices();
                result = ExecuteCommand(connection, forecast);

                //RadarSites
                var radarSites = new RadarSites();
                result = ExecuteCommand(connection, radarSites);
                //RadarFiles
                var radarFiles = new RadarFiles();
                result = ExecuteCommand(connection, radarFiles);
            }
            return result;
        }

        private int ExecuteCommand(SqlConnection connection, ICreateTable createTable)
        {
            var sql = createTable.CreateTable();
            var command = new SqlCommand(sql, connection);
            var result = command.ExecuteNonQuery();
            return result;
        }
    }
}
