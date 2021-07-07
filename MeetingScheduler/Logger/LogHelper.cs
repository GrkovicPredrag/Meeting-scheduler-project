using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class LogHelper
    {
        private static LogBase logger = null;
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.AddTimestamp(ref message);
                    logger.Log(message);
                    break;
                case LogTarget.Database:
                    logger = new DBLogger();
                    logger.AddTimestamp(ref message);
                    logger.Log(message);
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.AddTimestamp(ref message);
                    logger.Log(message);
                    break;
                case LogTarget.OutputLog:
                    logger = new OutputLogger();
                    logger.AddTimestamp(ref message);
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }

        public enum LogTarget
        {
            File, Database, EventLog, OutputLog
        }
    }
}
