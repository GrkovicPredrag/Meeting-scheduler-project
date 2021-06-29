using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class DBLogger : LogBase
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                //nesto
            }
        }
    }
}
