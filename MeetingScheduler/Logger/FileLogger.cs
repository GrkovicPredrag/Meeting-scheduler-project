using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger :ILogger
    {
        private string filePath;
        private StringBuilder sb;
        private object lockObj;

        public FileLogger(object lockobject)
        {
            sb = new StringBuilder();
            GetPath();
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
                    using (StreamWriter streamWriter = new StreamWriter(filePath, append: true))
                    {
                        streamWriter.WriteLineAsync(sb.ToString());
                        streamWriter.Close();
                    }
                }
            }
            catch(IOException ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
        }

        private void GetPath()
        {
            try
            {
                sb.Clear();
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                sb.Append(path);
                sb.Append("\\log.txt");
                filePath = sb.ToString();
                sb.Clear();
            }
            catch(IOException ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
        }

    }
}
