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
            sql += "[ForecastOfficeID]  INT NULL, ";
            sql += "[DateStamp]  DATETIME NOT NULL DEFAULT (GETDATE()), ";
            sql += "CONSTRAINT[PK_dbo.Forecasts] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
