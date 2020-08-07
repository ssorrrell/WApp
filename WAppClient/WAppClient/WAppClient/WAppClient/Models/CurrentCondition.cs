using System;
using System.Collections.Generic;
using System.Text;

namespace WAppClient.Models
{
    public class CurrentCondition : BaseModel
    {
        int _id = 0;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        string _location = string.Empty;
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }
        string _stationID = string.Empty;
        public string StationID
        {
            get { return _stationID; }
            set { SetProperty(ref _stationID, value); }
        }
        decimal _latitude = 0;
        public decimal Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref _latitude, value); }
        }
        decimal _longitude = 0;
        public decimal Longitude
        {
            get { return _longitude; }
            set { SetProperty(ref _longitude, value); }
        }
        DateTime _obsTime;
        public DateTime ObsTime
        {
            get { return _obsTime; }
            set { SetProperty(ref _obsTime, value); }
        }
        string _weather;
        public string Weather
        {
            get { return _weather; }
            set { SetProperty(ref _weather, value); }
        }
        decimal _tempF = 0;
        public decimal TempF
        {
            get { return _tempF; }
            set { SetProperty(ref _tempF, value); }
        }
        decimal _relHumidity = 0;
        public decimal RelHumidity
        {
            get { return _relHumidity; }
            set { SetProperty(ref _relHumidity, value); }
        }
        string _windDir;
        public string WindDir
        {
            get { return _windDir; }
            set { SetProperty(ref _windDir, value); }
        }
        int _windDegrees = 0;
        public int WindDegrees
        {
            get { return _windDegrees; }
            set { SetProperty(ref _windDegrees, value); }
        }
        decimal _windMPH = 0;
        public decimal WindMPH
        {
            get { return _windMPH; }
            set { SetProperty(ref _windMPH, value); }
        }
        string _windString;
        public string WindString
        {
            get { return _windString; }
            set { SetProperty(ref _windString, value); }
        }
        decimal _pressureIn = 0;
        public decimal PressureIn
        {
            get { return _pressureIn; }
            set { SetProperty(ref _pressureIn, value); }
        }
        decimal _dewPointF = 0;
        public decimal DewPointF
        {
            get { return _dewPointF; }
            set { SetProperty(ref _dewPointF, value); }
        }
        decimal _visibilityMiles = 0;
        public decimal VisibilityMiles
        {
            get { return _visibilityMiles; }
            set { SetProperty(ref _visibilityMiles, value); }
        }
        DateTime _dateStamp;
        public DateTime DateStamp
        {
            get { return _dateStamp; }
            set { SetProperty(ref _dateStamp, value); }
        }
    }
}
