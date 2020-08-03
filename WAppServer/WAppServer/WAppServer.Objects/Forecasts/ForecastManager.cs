using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WAppServer.Framework.Data;
using WAppServer.Objects.Common;
using WAppServer.Objects.Helpers;

namespace WAppServer.Objects.Forecasts
{
    public class ForecastManager : EntityManager
    {
        public ForecastManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public async Task UpdateAsync(string callSign, string latitude, string longitude)
        {
            //download file
            var localPath = Path.Combine(Constants.BaseFilePath, "Forecasts", callSign);
            var url = Forecast.UrlTemplate.Replace("xxxx", latitude).Replace("yyyy", longitude);
            var result = await RssHelper.GetStreamAsync(url, localPath);
            //parse file
            var doc = XDocument.Load(localPath);
            var forecast = GetForecastFromXDoc(doc);
            //save to db
        }

        public Forecast GetForecastFromXDoc(XDocument doc)
        {
            var returnForecast = new Forecast(SqlConnection);

            //populate forecast
            Dictionary<string,List<string>> timeLayoutKeys = new Dictionary<string, List<string>>();
            foreach (var forecastNode in doc.Descendants("data"))
            {
                if (forecastNode == null)
                    continue;
                var attributeValue = RssHelper.GetStringValueFromAttribute(forecastNode, "type");
                if (!string.IsNullOrEmpty(attributeValue) && attributeValue == "forecast")
                {
                    foreach (var forecastNodeChild in forecastNode.Descendants())
                    {
                        if (forecastNodeChild.Name == "time-layout")
                        {
                            var name = "";
                            var timeLayoutList = new List<string>();
                            foreach (var parameterNodeChild in forecastNodeChild.Descendants())
                            {
                                if (parameterNodeChild.Name == "layout-key")
                                {
                                    name = parameterNodeChild.Value;
                                }
                                if (parameterNodeChild.Name == "start-valid-time")
                                {
                                    var paramAttributeValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "period-name");
                                    if (!string.IsNullOrEmpty(paramAttributeValue))
                                        timeLayoutList.Add(paramAttributeValue);
                                }
                            }
                            if (!string.IsNullOrEmpty(name) && timeLayoutList.Count > 0)
                                timeLayoutKeys.Add(name, timeLayoutList);
                        }
                        if (forecastNodeChild.Name == "parameters")
                        {
                            foreach (var parameterNodeChild in forecastNodeChild.Descendants()) //temperature or probability-of-precipitation
                            {
                                var paramNodeAttributeValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "type");
                                if (parameterNodeChild.Name == "temperature" && !string.IsNullOrEmpty(paramNodeAttributeValue) && paramNodeAttributeValue == "minimum")
                                {
                                    var timeLayoutValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "time-layout");
                                    var timeLayout = timeLayoutKeys[timeLayoutValue];
                                    var minDailyTempList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.DailyMinTemp, timeLayout);
                                    returnForecast.DailyMinTemp = minDailyTempList;
                                }
                                paramNodeAttributeValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "type");
                                if (parameterNodeChild.Name == "temperature" && !string.IsNullOrEmpty(paramNodeAttributeValue) && paramNodeAttributeValue == "maximum")
                                {
                                    var timeLayoutValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "time-layout");
                                    var timeLayout = timeLayoutKeys[timeLayoutValue];
                                    var maxDailyTempList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.DailyMaxTemp, timeLayout);
                                    returnForecast.DailyMaxTemp = maxDailyTempList;
                                }
                                paramNodeAttributeValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "type");
                                if (parameterNodeChild.Name == "probability-of-precipitation" && !string.IsNullOrEmpty(paramNodeAttributeValue) && paramNodeAttributeValue == "12 hour")
                                {
                                    var timeLayoutValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "time-layout");
                                    var timeLayout = timeLayoutKeys[timeLayoutValue];
                                    var hourlyPrecipProbList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.HourlyProbPrecip, timeLayout);
                                    returnForecast.HourlyProbPrecip = hourlyPrecipProbList;
                                }
                                if (parameterNodeChild.Name == "weather")
                                {
                                    var timeLayoutValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "time-layout");
                                    if (!string.IsNullOrEmpty(timeLayoutValue) && timeLayoutKeys.ContainsKey(timeLayoutValue))
                                    {
                                        var timeLayout = timeLayoutKeys[timeLayoutValue];
                                        var weatherType = GetForecastWeatherList(parameterNodeChild, ForecastText.Text.WeatherType, timeLayout);
                                        returnForecast.WeatherType = weatherType;
                                    }
                                }
                                if (parameterNodeChild.Name == "wordedForecast")
                                {
                                    var timeLayoutValue = RssHelper.GetStringValueFromAttribute(parameterNodeChild, "time-layout");
                                    if (!string.IsNullOrEmpty(timeLayoutValue) && timeLayoutKeys.ContainsKey(timeLayoutValue))
                                    {
                                        var timeLayout = timeLayoutKeys[timeLayoutValue];
                                        var weatherText = GetForecastTextList(parameterNodeChild, ForecastText.Text.ForecastText, timeLayout);
                                        returnForecast.ForecastText = weatherText;
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }

            return returnForecast;
        }

        private List<ForecastDetails> GetForecastDetailList(XElement parameterNodeChild, ForecastDetails.Detail detailType, List<string> timeLayout)
        {
            int i = -1;
            var detailList = new List<ForecastDetails>();
            foreach (var value in parameterNodeChild.Descendants())
            {
                if (i >= 0)
                {   //skip the first one, that is text
                    var newDetail = new ForecastDetails()
                    {
                        DetailType = detailType,
                        Name = timeLayout[i],
                        Value = RssHelper.GetDecimalFromValue(value)
                    };
                    detailList.Add(newDetail);
                }
                i++;
            }
            return detailList;
        }

        private List<ForecastText> GetForecastWeatherList(XElement parameterNodeChild, ForecastText.Text textType, List<string> timeLayout)
        {
            int i = -1;
            var detailList = new List<ForecastText>();
            foreach (var value in parameterNodeChild.Descendants())
            {
                if (i >= 0)
                {   //skip the first one, that is text
                    var newDetail = new ForecastText()
                    {
                        TextType = textType,
                        Name = timeLayout[i],
                        Value = RssHelper.GetStringValueFromAttribute(value, "weather-summary"),
                    };
                    detailList.Add(newDetail);
                }
                i++;
            }
            return detailList;
        }

        private List<ForecastText> GetForecastTextList(XElement parameterNodeChild, ForecastText.Text textType, List<string> timeLayout)
        {
            int i = -1;
            var detailList = new List<ForecastText>();
            foreach (var value in parameterNodeChild.Descendants())
            {
                if (i >= 0)
                {   //skip the first one, that is text
                    var newDetail = new ForecastText()
                    {
                        TextType = textType,
                        Name = timeLayout[i],
                        Value = RssHelper.GetStringFromValue(value)
                    };
                    detailList.Add(newDetail);
                }
                i++;
            }
            return detailList;
        }
    }
}
