using System;

namespace WAppServer.Migrate
{
    public class Forecasts : ICreateTable
    {
        public Forecasts() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[Forecasts] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[UGC]  NVARCHAR(MAX) NULL, ";
            sql += "[DailyMinTemp]  INT NULL, ";
            sql += "[DailyMaxTemp]  INT NULL, ";
            sql += "[HourlyProbPrecip]  INT NULL, ";
            sql += "[WeatherType]  INT NULL, ";
            sql += "[Forecast]  INT NULL, ";
            sql += "[DateStamp]  DATETIME NOT NULL DEFAULT (GETDATE()), ";
            sql += "CONSTRAINT[PK_dbo.Forecasts] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
