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
            var currentConditions = GetCurrentConditionFromXDoc(doc);
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
                returnCondition.SugPickup = RssHelper.GetStringFromValue(currentObs.Element("suggested_pickup"));
                returnCondition.SugPickupPeriod = RssHelper.GetStringFromValue(currentObs.Element("suggested_pickup_period"));
                returnCondition.StationID = RssHelper.GetStringFromValue(currentObs.Element("station_id"));
                returnCondition.Latitude = RssHelper.GetDecimalFromValue(currentObs.Element("latitude"));
                returnCondition.Longitude = RssHelper.GetDecimalFromValue(currentObs.Element("longitude"));
                returnCondition.ObsTime = RssHelper.GetDateTimeFromValue(currentObs.Element("observation_time_rfc822"));
                returnCondition.Weather = RssHelper.GetStringFromValue(currentObs.Element("weather"));
                returnCondition.TempF = RssHelper.GetDecimalFromValue(currentObs.Element("temp_f"));
                returnCondition.RelHumidity = RssHelper.GetDecimalFromValue(currentObs.Element("relative_humidity"));
                returnCondition.WindDir = RssHelper.GetStringFromValue(currentObs.Element("wind_dir"));
                returnCondition.WindDegrees = RssHelper.GetIntFromValue(currentObs.Element("wind_degrees"));
                returnCondition.WindMPH = RssHelper.GetDecimalFromValue(currentObs.Element("wind_mph"));
                returnCondition.PressureIn = RssHelper.GetDecimalFromValue(currentObs.Element("pressure_in"));
                returnCondition.DewPointF = RssHelper.GetDecimalFromValue(currentObs.Element("dewpoint_f"));
                returnCondition.VisibilityMiles = RssHelper.GetDecimalFromValue(currentObs.Element("visibility_mi"));
                break;
            }

            return returnCondition;
        }
    }
}
