using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogLib
{
    /// <summary>
    /// The class for logging functionality (writing to file).
    /// </summary>
    public class TxtLogger : ILoggingService
    {
        /// <summary>
        /// the name of the file to log to.
        /// </summary>
        public string LogFile { get; set; }

        

        /// <summary>
        /// Create a logger with the default name, which is current date and time.
        /// </summary>
        public TxtLogger()
        {
            LogFile = DateTime.Now.Year.ToString() +
                "_" + DateTime.Now.Month.ToString() +
                "_" + DateTime.Now.Day.ToString() +
                "_" + DateTime.Now.Hour.ToString() +
                "_" + DateTime.Now.Minute.ToString() +
                "_" + DateTime.Now.Second.ToString() +
                "_" + DateTime.Now.Millisecond.ToString() +
                ".txt";
        }

        /// <summary>
        /// Add a message to the log file, appending.
        /// </summary>
        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(LogFile))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
