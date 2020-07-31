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
