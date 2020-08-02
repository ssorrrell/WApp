using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NLog.LayoutRenderers.Wrappers;
using WAppServer.Framework.Data;
using WAppServer.Objects.Common;
using WAppServer.Objects.Helpers;

namespace WAppServer.Objects.CurrentConditions
{
    public class CurrentConditionsManager : EntityManager
    {
        public CurrentConditionsManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public async Task UpdateAsync(string callSign)
        {
            //download file
            var localPath = Path.Combine(Constants.BaseFilePath, "CurrentConditions", callSign);
            var url = CurrentConditions.UrlTemplate.Replace("xxxx", callSign);
            var result = await RssHelper.GetStreamAsync(url, localPath);
            //parse file
            var doc = RssHelper.GetXDocFromFile(localPath);
            //save to db
        }

        public CurrentConditions GetCurrentConditionFromXDoc(XDocument doc)
        {
            var returnCondition = new CurrentConditions();

            //populate feedItem
            foreach (var currentObs in doc.Descendants("current_observation"))
            {
                if (currentObs == null)
                    continue;
                returnCondition.SugPickup = RssHelper.ConvertXElementToString(currentObs.Element("suggested_pickup"));
                returnCondition.SugPickupPeriod = RssHelper.ConvertXElementToString(currentObs.Element("suggested_pickup_period"));
                returnCondition.StationID = RssHelper.ConvertXElementToString(currentObs.Element("station_id"));
                returnCondition.Latitude = RssHelper.ConvertXElementToDecimal(currentObs.Element("latitude"));
                returnCondition.Longitude = RssHelper.ConvertXElementToDecimal(currentObs.Element("longitude"));
                returnCondition.ObsTime = RssHelper.ConvertXElementToDateTime(currentObs.Element("observation_time_rfc822"));
                returnCondition.Weather = RssHelper.ConvertXElementToString(currentObs.Element("weather"));
                returnCondition.TempF = RssHelper.ConvertXElementToDecimal(currentObs.Element("temp_f"));
                returnCondition.RelHumidity = RssHelper.ConvertXElementToDecimal(currentObs.Element("relative_humidity"));
                returnCondition.WindDir = RssHelper.ConvertXElementToString(currentObs.Element("wind_dir"));
                returnCondition.WindDegrees = RssHelper.ConvertXElementToInt(currentObs.Element("wind_degrees"));
                returnCondition.WindMPH = RssHelper.ConvertXElementToDecimal(currentObs.Element("wind_mph"));
                returnCondition.PressureIn = RssHelper.ConvertXElementToDecimal(currentObs.Element("pressure_in"));
                returnCondition.DewPointF = RssHelper.ConvertXElementToDecimal(currentObs.Element("dewpoint_f"));
                returnCondition.VisibilityMiles = RssHelper.ConvertXElementToDecimal(currentObs.Element("visibility_mi"));
                break;
            }

            return returnCondition;
        }
    }
}
