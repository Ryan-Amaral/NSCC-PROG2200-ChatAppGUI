using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    /// <summary>
    /// Implements LogThis, and uses its LogThis method to log.
    /// Outputs to a file in the executing directory called LogLib_YEARMM.
    /// </summary>
    public class MyLogThis : ILoggingService
    {
        /// <summary>
        /// Log message to log file in executable's folder.
        /// </summary>
        public MyLogThis()
        {
            LogLib.Log tmp = new LogLib.Log();
            tmp.Init();
            LogLib.Log.UseSensibleDefaults();
            LogLib.Log.LogLevel = eloglevel.verbose;
        }

        /// <summary>
        /// Uses LogThis's Log.LogThis method to log.
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            LogLib.Log.LogThis(message, eloglevel.verbose);
        }
    }
}
