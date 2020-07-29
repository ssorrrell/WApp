using System;

namespace WAppServer.Migrate
{
    public class ForecastDetails : ICreateTable
    {
        public ForecastDetails() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[ForecastDetails] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[Value]  NVARCHAR(MAX) NULL, ";
            sql += "[ForecastID]  INT NULL, ";
            sql += "CONSTRAINT[PK_dbo.ForecastDetails] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
