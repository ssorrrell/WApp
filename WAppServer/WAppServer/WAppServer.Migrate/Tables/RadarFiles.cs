using System;

namespace WAppServer.Migrate
{
    public class RadarFiles : ICreateTable
    {
        public RadarFiles() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[RadarFiles] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[ICAO] NVARCHAR(MAX) NULL, ";
            sql += "[LayerType] INT NULL, ";
            sql += "[DateStamp]  DATETIME NOT NULL DEFAULT (GETDATE()), ";
            sql += "CONSTRAINT[PK_dbo.RadarFiles] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
