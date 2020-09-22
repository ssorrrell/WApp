using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WAppClient.Models.Seed
{
    public class SeedData
    {
        public static CurrentCondition GetCurrentCondition()
        {
            var currentCondition = new CurrentCondition();
            currentCondition.DewPointF = 66.9m;
            currentCondition.ID = 1;
            currentCondition.Latitude = 35.22m;
            currentCondition.Longitude = -101.71722m;
            currentCondition.ObsTime = DateTime.Now;
            currentCondition.PressureIn = 30.09m;
            currentCondition.RelHumidity = 84;
            currentCondition.StationID = "KAMA";
            currentCondition.TempF = 72.0m;
            currentCondition.VisibilityMiles = 10;
            currentCondition.Weather = "A Few Clouds";
            currentCondition.WindDegrees = 150;
            currentCondition.WindDir = "Southeast";
            currentCondition.WindMPH = 10.4m;
            currentCondition.WindString = $"{currentCondition.WindDir} at {currentCondition.WindMPH}mph";
            return currentCondition;
        }

        public static Forecast GetForecastObject()
        {
            var forecast = new Forecast();
            forecast.DateStamp = DateTime.Now;
            var forecastHalfDayList = new ObservableCollection<ForecastHalfDay>();
            var forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tonight",
                MinTempF = 69,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Partly cloudy, with a low around 69. South southeast wind around 10 mph, with gusts as high as 20 mph. ",
                WeatherCondition = "Partly Cloudy"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Friday",
                MinTempF = 69,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "Isolated showers and thunderstorms after 2pm.  Mostly sunny, with a high near 92. South southeast wind 10 to 15 mph.  Chance of precipitation is 20%.",
                WeatherCondition = "Mostly Sunny then Isolated T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Friday Night",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly clear, with a low around 68. South southeast wind around 15 mph, with gusts as high as 20 mph. ",
                WeatherCondition = "Mostly Clear"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Saturday",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 92. South wind 10 to 15 mph. ",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Saturday Night",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly clear, with a low around 68. South southeast wind 10 to 15 mph. ",
                WeatherCondition = "Mostly Clear"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Sunday",
                MinTempF = 68,
                MaxTempF = 93,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 93. South southeast wind around 10 mph. ",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Sunday Night",
                MinTempF = 68,
                MaxTempF = 93,
                PropPrecip = 0,
                WeatherText = "Partly cloudy, with a low around 68. South southeast wind 10 to 15 mph. ",
                WeatherCondition = "Partly Cloudy"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Monday",
                MinTempF = 68,
                MaxTempF = 89,
                PropPrecip = 40,
                WeatherText = "A 40 percent chance of showers and thunderstorms.  Partly sunny, with a high near 89. Southwest wind around 5 mph becoming east northeast in the afternoon. ",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Monday Night",
                MinTempF = 68,
                MaxTempF = 89,
                PropPrecip = 40,
                WeatherText = "A 40 percent chance of showers and thunderstorms.  Mostly cloudy, with a low around 66. East southeast wind 5 to 10 mph. ",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tuesday",
                MinTempF = 66,
                MaxTempF = 87,
                PropPrecip = 30,
                WeatherText = "A 30 percent chance of showers and thunderstorms.  Partly sunny, with a high near 87.",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tuesday Night",
                MinTempF = 87,
                MaxTempF = 92,
                PropPrecip = 30,
                WeatherText = "A 30 percent chance of showers and thunderstorms.  Mostly cloudy, with a low around 66.",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Wednesday",
                MinTempF = 91,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "A 20 percent chance of showers and thunderstorms.  Mostly sunny, with a high near 91.",
                WeatherCondition = "Slight Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Wednesday Night",
                MinTempF = 91,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "A 20 percent chance of showers and thunderstorms.  Partly cloudy, with a low around 66.",
                WeatherCondition = "Slight Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Thursday",
                MinTempF = 93,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 93.",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecast.ForecastHalfDays = forecastHalfDayList;
            return forecast;
        }

        public static ObservableCollection<ForecastHalfDay> GetForecastHalfDays()
        {
            var forecastHalfDayList = new ObservableCollection<ForecastHalfDay>();
            var forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tonight",
                MinTempF = 69,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Partly cloudy, with a low around 69. South southeast wind around 10 mph, with gusts as high as 20 mph. ",
                WeatherCondition = "Partly Cloudy"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Friday",
                MinTempF = 69,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "Isolated showers and thunderstorms after 2pm.  Mostly sunny, with a high near 92. South southeast wind 10 to 15 mph.  Chance of precipitation is 20%.",
                WeatherCondition = "Mostly Sunny then Isolated T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Friday Night",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly clear, with a low around 68. South southeast wind around 15 mph, with gusts as high as 20 mph. ",
                WeatherCondition = "Mostly Clear"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Saturday",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 92. South wind 10 to 15 mph. ",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Saturday Night",
                MinTempF = 68,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly clear, with a low around 68. South southeast wind 10 to 15 mph. ",
                WeatherCondition = "Mostly Clear"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Sunday",
                MinTempF = 68,
                MaxTempF = 93,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 93. South southeast wind around 10 mph. ",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Sunday Night",
                MinTempF = 68,
                MaxTempF = 93,
                PropPrecip = 0,
                WeatherText = "Partly cloudy, with a low around 68. South southeast wind 10 to 15 mph. ",
                WeatherCondition = "Partly Cloudy"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Monday",
                MinTempF = 68,
                MaxTempF = 89,
                PropPrecip = 40,
                WeatherText = "A 40 percent chance of showers and thunderstorms.  Partly sunny, with a high near 89. Southwest wind around 5 mph becoming east northeast in the afternoon. ",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Monday Night",
                MinTempF = 68,
                MaxTempF = 89,
                PropPrecip = 40,
                WeatherText = "A 40 percent chance of showers and thunderstorms.  Mostly cloudy, with a low around 66. East southeast wind 5 to 10 mph. ",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tuesday",
                MinTempF = 66,
                MaxTempF = 87,
                PropPrecip = 30,
                WeatherText = "A 30 percent chance of showers and thunderstorms.  Partly sunny, with a high near 87.",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Tuesday Night",
                MinTempF = 87,
                MaxTempF = 92,
                PropPrecip = 30,
                WeatherText = "A 30 percent chance of showers and thunderstorms.  Mostly cloudy, with a low around 66.",
                WeatherCondition = "Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Wednesday",
                MinTempF = 91,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "A 20 percent chance of showers and thunderstorms.  Mostly sunny, with a high near 91.",
                WeatherCondition = "Slight Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Wednesday Night",
                MinTempF = 91,
                MaxTempF = 92,
                PropPrecip = 20,
                WeatherText = "A 20 percent chance of showers and thunderstorms.  Partly cloudy, with a low around 66.",
                WeatherCondition = "Slight Chance T-storms"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            forecastHalfDay = new ForecastHalfDay
            {
                Name = "Thursday",
                MinTempF = 93,
                MaxTempF = 92,
                PropPrecip = 0,
                WeatherText = "Mostly sunny, with a high near 93.",
                WeatherCondition = "Mostly Sunny"
            };
            forecastHalfDayList.Add(forecastHalfDay);
            return forecastHalfDayList;
        }
    }
}
