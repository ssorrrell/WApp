using System;
using System.Collections.Generic;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastOffice : Entity
    {
        public int ID;
        public string Office;
        public string State;
        public string CallSign;
        public decimal Latitude;
        public decimal Longitude;
    }
}
