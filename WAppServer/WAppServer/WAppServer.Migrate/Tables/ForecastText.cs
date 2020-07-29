using System;

namespace WAppServer.Migrate
{
    public class ForecastText : ICreateTable
    {
        public ForecastText() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[ForecastText] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[Value]  NVARCHAR(MAX) NULL, ";
            sql += "[ForecastID]  INT NULL, ";
            sql += "CONSTRAINT[PK_dbo.ForecastText] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
