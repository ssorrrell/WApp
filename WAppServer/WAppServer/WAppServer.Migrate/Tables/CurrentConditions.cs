using System;

namespace WAppServer.Migrate
{
    public class CurrentConditions : ICreateTable
    {
        public CurrentConditions() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[CurrentConditions] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[UGC]  NVARCHAR(MAX) NULL, ";
            sql += "[Location]  NVARCHAR(MAX) NULL, ";
            sql += "[SugPickup]  NVARCHAR(MAX) NULL, ";
            sql += "[SugPickupPeriod]  INT NULL, ";
            sql += "[StationID]  NVARCHAR(MAX) NULL, ";
            sql += "[Latitude]  DECIMAL(8,6) NULL, ";
            sql += "[Longitude]  DECIMAL(9,6) NULL, ";
            sql += "[ObsTime]  DATETIME NULL, ";
            sql += "[Weather]  NVARCHAR(MAX) NULL, ";
            sql += "[TempF]  DECIMAL(5,2) NULL, ";
            sql += "[RelHumidity]  DECIMAL(5,2) NULL, ";
            sql += "[WindDir]  NVARCHAR(MAX) NULL, ";
            sql += "[WindDegrees]  DECIMAL(5,0) NULL, ";
            sql += "[WindMPH]  DECIMAL(3,1) NULL, ";
            sql += "[PressureIn]  DECIMAL(3,1) NULL, ";
            sql += "[DewPointF]  DECIMAL(5,2) NULL, ";
            sql += "[VisibleMiles]  DECIMAL(3,1) NULL, ";
            sql += "[DateStamp]  DATETIME NOT NULL DEFAULT (GETDATE()), ";
            sql += "CONSTRAINT[PK_dbo.CurrentConditions] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
