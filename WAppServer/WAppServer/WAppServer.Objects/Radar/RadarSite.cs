using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Radar
{
    public class RadarSite : Entity
    {
        public int ID;
        public string Nexrad;
        public string City;
        public string State;
        public string ICAO;
        public string StationID;
    }
}
