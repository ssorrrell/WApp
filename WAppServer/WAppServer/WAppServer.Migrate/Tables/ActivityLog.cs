using System;

namespace WAppServer.Migrate
{
    public class ActivityLog
    {
        public ActivityLog() { }

        public string CreateTable()
        {
            var sql = "CREATE TABLE [dbo].[ActivityLog] (";
            sql += "[ID] INT IDENTITY(1, 1) NOT NULL, ";
            sql += "[Source]  NVARCHAR(MAX) NULL, ";
            sql += "[Activity]  NVARCHAR(MAX) NULL, ";
            sql += "[LogLevel]  INT NULL, ";
            sql += "[DateStamp]  DATETIME NOT NULL DEFAULT (GETDATE()), ";
            sql += "CONSTRAINT[PK_dbo.ActivityLog] PRIMARY KEY CLUSTERED([ID] ASC)); ";
            return sql;
        }

    }
}
