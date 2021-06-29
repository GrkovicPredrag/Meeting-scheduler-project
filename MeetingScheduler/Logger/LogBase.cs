﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }

    public enum LogTarget
    {
        File, Database, EventLog
    }
}