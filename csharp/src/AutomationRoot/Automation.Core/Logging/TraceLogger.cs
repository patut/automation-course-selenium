using System;
using System.Diagnostics;

namespace Automation.Core.Logging
{
    public class TraceLogger : ILogger
    {
        public void Debug(string message)
        {
            Trace.TraceInformation(message);
        }

        public void Format(string message, params object[] args)
        {
            Trace.TraceInformation(string.Format(message, args));
        }

        public void Exception(Exception exception, string message)
        {
            Trace.TraceError($"{message} {exception}");
        }
    }
}