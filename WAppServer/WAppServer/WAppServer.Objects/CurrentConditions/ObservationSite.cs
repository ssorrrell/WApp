using System;
using System.Collections.Generic;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.CurrentConditions
{
    public class ObservationSite : Entity
    {
        public int ID;
        public string Office;
        public string State;
        public string CallSign; //https://w1.weather.gov/xml/current_obs/<CallSign>.xml
    }
}
