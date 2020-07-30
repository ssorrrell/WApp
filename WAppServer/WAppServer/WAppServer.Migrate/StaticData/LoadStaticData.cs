using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Objects.CurrentConditions;
using WAppServer.Objects.DBConnection;
using WAppServer.Objects.Forecasts;
using WAppServer.Objects.Radar;

namespace WAppServer.Migrate.StaticData
{
    public class LoadStaticData
    {
        public LoadStaticData()
        {
        }

        public int RadarSites()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString: DB.ConnectionString))
            {
                var radarSiteManager = new RadarSiteManager(connection);
                var radarSite = new RadarSite
                {
                    State = "TX",
                    City = "Amarillo",
                    ICAO = "KAMA",
                    Nexrad = "AMARILLO",
                    StationID = "AMA"
                };
                radarSiteManager.Create(radarSite);
                radarSite = new RadarSite
                {
                    State = "NM",
                    City = "Albuquerque",
                    ICAO = "KABX",
                    Nexrad = "ALBUQUERQUE",
                    StationID = "ABQ"
                };
                radarSiteManager.Create(radarSite);
                radarSite = new RadarSite
                {
                    State = "OK",
                    City = "Tulsa",
                    ICAO = "KINX",
                    Nexrad = "TULSA",
                    StationID = "TSA"
                };
                radarSiteManager.Create(radarSite);
                radarSite = new RadarSite
                {
                    State = "TX",
                    City = "Lubbock",
                    ICAO = "KLBB",
                    Nexrad = "LUBBOCK",
                    StationID = "LUB"
                };
                radarSiteManager.Create(radarSite);
                radarSite = new RadarSite
                {
                    State = "OR",
                    City = "Portland",
                    ICAO = "KRTX",
                    Nexrad = "PORTLAND",
                    StationID = "PQR"
                };
                radarSiteManager.Create(radarSite);
            }
            return result;
        }

        public int ForecastOffices()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString: DB.ConnectionString))
            {
                var forecastOfficeManager = new ForecastOfficeManager(connection);
                var forecastOffice = new ForecastOffice
                {
                    State = "TX",
                    Office = "Amarillo",
                    CallSign = "AMA",
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "TX",
                    Office = "Lubbock",
                    CallSign = "LUB",
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "NM",
                    Office = "Albuquerque",
                    CallSign = "ABQ",
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "OK",
                    Office = "Tulsa",
                    CallSign = "TSA",
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "OR",
                    Office = "Portland",
                    CallSign = "PQR",
                };
                forecastOfficeManager.Create(forecastOffice);
            }
            return result;
        }

        public int ObservationSites()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString: DB.ConnectionString))
            {
                var observationSiteManager = new ObservationSiteManager(connection);
                var observationSite = new ObservationSite
                {
                    State = "TX",
                    Office = "Amarillo",
                    CallSign = "KAMA",
                };
                observationSiteManager.Create(observationSite);
                observationSite = new ObservationSite
                {
                    State = "NM",
                    Office = "Albuquerque",
                    CallSign = "KABX",
                };
                observationSiteManager.Create(observationSite);
                observationSite = new ObservationSite
                {
                    State = "OK",
                    Office = "Tulsa",
                    CallSign = "KINX",
                };
                observationSiteManager.Create(observationSite);
                observationSite = new ObservationSite
                {
                    State = "TX",
                    Office = "Lubbock",
                    CallSign = "KLBB",
                };
                observationSiteManager.Create(observationSite);
                observationSite = new ObservationSite
                {
                    State = "OR",
                    Office = "Portland",
                    CallSign = "KRTX",
                };
                observationSiteManager.Create(observationSite);
            }
            return result;
        }
    }
}
