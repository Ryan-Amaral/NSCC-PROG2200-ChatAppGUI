using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    /// <summary>
    /// Interface for logging
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Method that logs
        /// </summary>
        /// <param name="message"></param>
        void Log(String message);
    }
}
