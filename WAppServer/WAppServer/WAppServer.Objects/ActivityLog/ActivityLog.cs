using System;

using NLog;
using NLog.Config;
using NLog.Targets;

namespace WAppServer.Objects.Models
{
    public class ActivityLog
    {   //Wrap NLog to abstract the selected logger

        private static Logger logger = null;
        private static readonly Lazy<ActivityLog> //lazy implementor
            lazy =
            new Lazy<ActivityLog>
                (() => new ActivityLog());

        public static ActivityLog Instance { get { return lazy.Value; } }

        private ActivityLog()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget
            {
                Name = "file",
                FileName = "log.txt",
                ArchiveFileName = "log.{#}.txt",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveDateFormat = "yyyyMMdd",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}|${stacktrace}",
            };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget, "*");
            LogManager.Configuration = config;
            logger = LogManager.GetLogger("WAppServer");
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(Exception ex)
        {
            logger.Debug(ex);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Fatal(Exception ex)
        {
            logger.Fatal(ex);
        }
    }
}
