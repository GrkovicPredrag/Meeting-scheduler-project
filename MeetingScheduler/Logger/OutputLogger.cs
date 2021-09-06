using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class OutputLogger : ILogger
    {
        private StringBuilder sb;
        private object lockObj;

        public OutputLogger(object lockobject)
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
                    Debug.WriteLine(sb.ToString());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            
        }
    }
}
