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
                    Longitude = (decimal)-101.705,
                    Latitude = (decimal)35.229,
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "TX",
                    Office = "Lubbock",
                    CallSign = "LUB",
                    Longitude = (decimal)-101.810,
                    Latitude = (decimal)33.650,
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "NM",
                    Office = "Albuquerque",
                    CallSign = "ABQ",
                    Longitude = (decimal)-106.819,
                    Latitude = (decimal)35.146,
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "OK",
                    Office = "Tulsa",
                    CallSign = "TSA",
                    Longitude = (decimal)-95.560,
                    Latitude = (decimal)36.171,
                };
                forecastOfficeManager.Create(forecastOffice);
                forecastOffice = new ForecastOffice
                {
                    State = "OR",
                    Office = "Portland",
                    CallSign = "PQR",
                    Longitude = (decimal)-122.959,
                    Latitude = (decimal)45.710,
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
                    State = "TX",
                    Office = "Lubbock",
                    CallSign = "KLBB",
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
