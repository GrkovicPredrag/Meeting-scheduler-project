using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class LoggerFactory
    {
        public static readonly object lockObj = new object();

        public static ILogger Create(LoggingOption option)
        {
            ILogger logger = null;

            switch (option)
            {
                case LoggingOption.File:
                    logger = new FileLogger(lockObj);
                    break;
                case LoggingOption.EventLog:
                    logger = new EventLogger(lockObj);
                    break;
                case LoggingOption.Output:
                    logger = new OutputLogger(lockObj);
                    break;
            }

            return logger;
        }

        public enum LoggingOption
        {
            File, EventLog, Output
        }
    }
}
