using System;
using System.Collections.Generic;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.CurrentConditions
{
    public class CurrentConditions : Entity
    {
        public int ID;
        public string Location;
        public string SugPickup;
        public string SugPickupPeriod;
        public string StationID;
        public decimal Latitude;
        public decimal Longitude;
        public DateTime ObsTime;
        public string Weather;
        public decimal TempF;
        public decimal RelHumidity;
        public string WindDir;
        public int WindDegrees;
        public decimal WindMPH;
        public decimal PressureIn;
        public decimal DewPointF;
        public decimal VisibilityMiles;
        public DateTime DateStamp;

        public const string UrlTemplate = "https://w1.weather.gov/xml/current_obs/xxxx.xml";
    }
}
