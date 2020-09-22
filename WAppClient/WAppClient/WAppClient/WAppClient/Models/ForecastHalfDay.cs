using System;
using System.Collections.Generic;
using System.Text;

namespace WAppClient.Models
{
    public class ForecastHalfDay
    {
        public string Name { get { return _name; } set { _name = value; } }
        private string _name;

        public decimal MinTempF { get { return _minTempF; } set { _minTempF = value; } }
        private decimal _minTempF;
        public decimal MaxTempF { get { return _maxTempF; } set { _maxTempF = value; } }
        private decimal _maxTempF;

        public decimal PropPrecip { get { return _propPrecip; } set { _propPrecip = value; } }
        private decimal _propPrecip;

        public string WeatherCondition { get { return _weatherCondition; } set { _weatherCondition = value; } }
        private string _weatherCondition;
        public string WeatherText { get { return _weatherText; } set { _weatherText = value; } }
        private string _weatherText;
    }
}
