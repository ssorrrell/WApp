using System;
using System.Collections.Generic;
using System.Text;

namespace WAppClient.Models
{
    public class ForecastHalfDay : BaseModel
    {
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }
        private string _name;

        public decimal MinTempF { get { return _minTempF; } set { SetProperty(ref _minTempF, value); } }
        private decimal _minTempF;
        public decimal MaxTempF { get { return _maxTempF; } set { SetProperty(ref _maxTempF, value); } }
        private decimal _maxTempF;

        public decimal PropPrecip { get { return _propPrecip; } set { SetProperty(ref _propPrecip, value); } }
        private decimal _propPrecip;

        public string WeatherCondition { get { return _weatherCondition; } set { SetProperty(ref _weatherCondition, value); } }
        private string _weatherCondition;
        public string WeatherText { get { return _weatherText; } set { SetProperty(ref _weatherText, value); } }
        private string _weatherText;
        public bool DisplayWeather { get { return _displayWeather; } set { SetProperty(ref _displayWeather, value); } }
        private bool _displayWeather;
    }
}
