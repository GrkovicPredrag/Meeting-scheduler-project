using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class EventLogger :ILogger
    {
        private StringBuilder sb;
        private object lockObj;

        public EventLogger(object lockobject)
        {
            sb = new StringBuilder();
            lockObj = lockobject;
        }

        public void Log(string message)
        {
            //timestamp
            sb.Clear();
            sb.Append(message);
            sb.Append($" [{DateTime.Now.ToString()}]");
            //

            try
            {
                lock (lockObj)
                {
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry(sb.ToString(), EventLogEntryType.Information, 101, 1);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
        }
    }
}
