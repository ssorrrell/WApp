﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WAppServer.Objects.Radar
{
    public enum LayerType
    {
        BaseReflectivity124,
        CompositeReflectivity,
        StormRelativeMotion,
        BaseVelocity,
        OneHourPrecipitation,
        StormTotalPrecipitation,
        BaseReflectivity248
    }

    public class RadarLayerType
    {
        //The filename format for these recent images is: xxx_YYYYMMDD_hhmm_N??.gif, where
        //xxx - Radar site ID
        //YYYY - year
        //MM - month
        //DD - day
        //hh - hour
        //mm - minutes
        //N?? - image ID(N0R, N0S, etc.)

        //Topography
        public const string TopoShort = "https://radar.weather.gov/ridge/Overlays/Topo/Short/xxx_Topo_Short.jpg";
        public const string TopoLong = "https://radar.weather.gov/ridge/Overlays/Topo/Long/xxx_Topo_Long.jpg";
        //CountyLines
        public const string CountyShort = "https://radar.weather.gov/ridge/Overlays/County/Short/xxx_County_Short.gif";
        public const string CountyLong = "https://radar.weather.gov/ridge/Overlays/County/Long/xxx_County_Long.gif";
        //Rivers
        public const string RiversShort = "https://radar.weather.gov/ridge/Overlays/Rivers/Short/xxx_Rivers_Short.gif";
        public const string RiversLong = "https://radar.weather.gov/ridge/Overlays/Rivers/Long/xxx_Rivers_Long.gif";
        //Highways
        public const string HighwayShort = "https://radar.weather.gov/ridge/Overlays/Highways/Short/xxx_Highways_Short.gif";
        public const string HighwayLong = "https://radar.weather.gov/ridge/Overlays/Highways/Long/xxx_Highways_Long.gif";
        //Cities
        public const string CityShort = "https://radar.weather.gov/ridge/Overlays/Cities/Short/xxx_City_Short.gif";
        public const string CityLong = "https://radar.weather.gov/ridge/Overlays/Cities/Long/xxx_City_Long.gif";

        //Base Reflectivity 124
        public const string BaseReflectivity124Dir = "https://radar.weather.gov/ridge/RadarImg/N0R/xxx"; //(directory for past images)
        public const string BaseReflectivity124File = "https://radar.weather.gov/ridge/RadarImg/N0R/xxx_NCR_0.gif"; //(for current image)
        //Storm Relative Motion
        public const string StormRelMotionDir = "https://radar.weather.gov/ridge/RadarImg/N0S/xxx"; //(directory for past images)
        public const string StormRelMotionFile = "https://radar.weather.gov/ridge/RadarImg/N0S/xxx_NCR_0.gif"; //(for current image)
        //One-Hour Precipitation
        public const string OneHourPrecipDir = "https://radar.weather.gov/ridge/RadarImg/N1P/xxx"; //(directory for past images)
        public const string OneHourPrecipFile = "https://radar.weather.gov/ridge/RadarImg/N1P/xxx_NCR_0.gif"; //(for current image)
        //Composite Reflectivity
        public const string CompositeReflectivityDir = "https://radar.weather.gov/ridge/RadarImg/NCR/xxx"; //(directory for past images)
        public const string CompositeReflectivityFile = "https://radar.weather.gov/ridge/RadarImg/NCR/xxx_NCR_0.gif"; //(for current image)
        //Storm Total Precipitation
        public const string StormTotalPrecipDir = "https://radar.weather.gov/ridge/RadarImg/NTP/xxx"; //(directory for past images)
        public const string StormTotalPrecipFile = "https://radar.weather.gov/ridge/RadarImg/NTP/xxx_NTP_0.gif"; //(for current image)
        //Base Reflectivity 248
        public const string BaseReflectivity248Dir = "https://radar.weather.gov/ridge/RadarImg/N0Z/xxx"; //(directory for past images)
        public const string BaseReflectivity248File = "https://radar.weather.gov/ridge/RadarImg/N0Z/xxx_NCR_0.gif"; //(for current image)

        //Warnings Overlay
        //Short range
        public const string ShortWarningsDir = "https://radar.weather.gov/ridge/Warnings/Short/xxx"; //(directory for past images)
        public const string ShortWarningsFile = "https://radar.weather.gov/ridge/Warnings/Short/xxx_Warnings_0.gif"; //(for current image)
        //Long range
        public const string LongWarningsDir = "https://radar.weather.gov/ridge/Warnings/Long/xxx"; //(directory for past images)
        public const string LongWarningsFile = "https://radar.weather.gov/ridge/Warnings/Long/xxx_Warnings_0.gif"; //(for current image)

        //Legend Overlays
        //Base Reflectivity 124
        public const string BaseReflectivity124LegendDir = "https://radar.weather.gov/ridge/Legend/N0R/xxx"; //(directory for past images)
        public const string BaseReflectivity124LegendFile = "https://radar.weather.gov/ridge/Legend/N0R/xxx_N0R_Legend_0.gif"; //(for current image)
        //Base Velocity
        public const string BaseVelocityLegendDir = "https://radar.weather.gov/ridge/Legend/N0V/xxx"; //(directory for past images)
        public const string BaseVelocityLegendFile = "https://radar.weather.gov/ridge/Legend/N0V/xxx_N0V_Legend_0.gif"; //(for current image)
        //Storm Relative Motion
        public const string StormRelMotionLegendDir = "https://radar.weather.gov/ridge/Legend/N0S/xxx"; //(directory for past images)
        public const string StormRelMotionLegendFile = "https://radar.weather.gov/ridge/Legend/N0S/xxx_N0S_Legend_0.gif"; //(for current image)
        //One-Hour Precipitation
        public const string OneHourPrecipLegendDir = "https://radar.weather.gov/ridge/Legend/N1P/xxx"; //(directory for past images)
        public const string OneHourPrecipLegendFile = "https://radar.weather.gov/ridge/Legend/N1P/xxx_N1P_Legend_0.gif"; //(for current image)
        //Composite Reflectivity
        public const string CompositeReflectivityLegendDir = "https://radar.weather.gov/ridge/Legend/NCR/xxx"; //(directory for past images)
        public const string CompositeReflectivityLegendFile = "https://radar.weather.gov/ridge/Legend/NCR/xxx_NCR_Legend_0.gif"; //(for current image)
        //Storm Total Precipitation
        public const string StormTotalPrecipLegendDir = "https://radar.weather.gov/ridge/Legend/NTP/xxx"; //(directory for past images)
        public const string StormTotalPrecipLegendFile = "https://radar.weather.gov/ridge/Legend/NTP/xxx_NTP_Legend_0.gif"; //(for current image)
        //Base Reflectivity 248
        public const string BaseReflectivity248LegendDir = "https://radar.weather.gov/ridge/Legend/N0Z/xxx"; //(directory for past images)
        public const string BaseReflectivity248LegendFile = "https://radar.weather.gov/ridge/Legend/N0Z/xxx_N0Z_Legend_0.gif"; //(for current image)
    }
}
