using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

        public async Task UpdateAsync(string callSign)
        {
            //download file
            var localPath = Path.Combine(Constants.BaseFilePath, "Forecasts", callSign);
            var url = Forecast.UrlTemplate.Replace("xxxx", callSign);
            var result = await RssHelper.GetStreamAsync(url, localPath);
            //parse file
            //save to db
        }

        public Forecast GetForecastFromXDoc(XDocument doc)
        {
            var returnForecast = new Forecast(SqlConnection);

            //populate forecast
            List<ForecastDetails> maxDailyTempList = new List<ForecastDetails>();
            List<ForecastDetails> minDailyTempList = new List<ForecastDetails>();
            List<ForecastDetails> hourlyPrecipProbList = new List<ForecastDetails>();
            foreach (var forecastNode in doc.Descendants("data"))
            {
                if (forecastNode == null)
                    continue;
                if (forecastNode.FirstAttribute != null && forecastNode.FirstAttribute.Value == "forecast")
                {
                    foreach (var forecastNodeChild in forecastNode.Descendants())
                    {
                        if (forecastNodeChild.Name == "parameters")
                        {
                            foreach (var parameterNodeChild in forecastNodeChild.Descendants()) //temperature or probability-of-precipitation
                            {
                                if (parameterNodeChild.FirstAttribute != null && parameterNodeChild.FirstAttribute.Value == "minimum")
                                {
                                    minDailyTempList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.DailyMinTemp);
                                }
                                if (parameterNodeChild.FirstAttribute != null && parameterNodeChild.FirstAttribute.Value == "maximum")
                                {
                                    minDailyTempList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.DailyMaxTemp);
                                }
                                if (parameterNodeChild.Name == "probability-of-precipitation ")
                                {
                                    hourlyPrecipProbList = GetForecastDetailList(parameterNodeChild, ForecastDetails.Detail.HourlyProbPrecip);
                                }
                            }
                        }
                    }
                }
                break;
            }

            return returnForecast;
        }

        private List<ForecastDetails> GetForecastDetailList(XElement parameterNodeChild, ForecastDetails.Detail detailType)
        {
            var detailList = new List<ForecastDetails>();
            if (parameterNodeChild.FirstAttribute != null && parameterNodeChild.FirstAttribute.Value == "minimum")
            {
                foreach (var value in parameterNodeChild.Descendants())
                {
                    var newDetail = new ForecastDetails()
                    {
                        DetailType = detailType,
                        Value = RssHelper.ConvertXElementToDecimal(value)
                    };
                    detailList.Add(newDetail);
                }
            }
            return detailList;
        }
    }
}
