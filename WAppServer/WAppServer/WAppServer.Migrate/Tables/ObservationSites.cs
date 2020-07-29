using System;

namespace WAppServer.Migrate
{
    public class ObservationSites : ICreateTable
    {
        public ObservationSites() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[ObservationSites] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[Office]  NVARCHAR(MAX) NULL, ";
            sql += "[State]  NVARCHAR(MAX) NULL, ";
            sql += "[CallSign]  NVARCHAR(MAX) NULL, ";
            sql += "CONSTRAINT[PK_dbo.ObservationSites] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
