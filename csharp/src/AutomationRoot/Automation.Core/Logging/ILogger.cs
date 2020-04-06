using System;

namespace Automation.Core.Logging
{
    public interface ILogger
    {
        void Debug(string message);
        void Format(string message, params object[] args);
        void Exception(Exception exception, string message);
    }
}