using System;

namespace WAppServer.Migrate
{
    public class RadarSites : ICreateTable
    {
        public RadarSites() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[RadarSites] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[Nexrad] NVARCHAR(MAX) NULL, ";
            sql += "[City] NVARCHAR(MAX) NULL, ";
            sql += "[State] NVARCHAR(MAX) NULL, ";
            sql += "[ICAO] NVARCHAR(MAX) NULL, ";
            sql += "CONSTRAINT[PK_dbo.RadarSites] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
