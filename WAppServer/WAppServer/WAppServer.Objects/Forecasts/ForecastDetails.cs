using System;
using System.Collections.Generic;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastDetails : Entity
    {
        public enum Detail
        {
            DailyMinTemp, DailyMaxTemp, HourlyProbPrecip
        }

        public int ID;
        public decimal Value;
        public Detail DetailType;
        public int ForecastID;
    }
}
