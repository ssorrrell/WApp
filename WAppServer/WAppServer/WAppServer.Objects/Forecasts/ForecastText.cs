using System;
using System.Collections.Generic;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastText : Entity
    {
        public enum Text
        {
            WeatherType, ForecastText
        }

        public int ID;
        public string Value;
        public Text TextType;
        public int ForecastID;
    }
}
