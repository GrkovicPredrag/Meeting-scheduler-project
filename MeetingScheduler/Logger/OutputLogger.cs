using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class OutputLogger : LogBase
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                Debug.WriteLine(message);
            }
        }
    }
}
