using System;
using System.Net.Http;
using Automation.Core.Logging;

namespace Automation.Core.Components
{
    public class FluentRestApi : FluentBase
    {
        public FluentRestApi(HttpClient httpClient) 
            : this(httpClient, new TraceLogger())
        {
        }

        public FluentRestApi(HttpClient httpClient, ILogger logger)
            : base(logger)
        {
            HttpClient = httpClient ?? new HttpClient();
        }

        public HttpClient HttpClient { get; }
        
        public override T ChangeContext<T>(string application)
        {
            return ChangeContext<T>(application, (ILogger) null);
        }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(null, logger);
        }

        public override T ChangeContext<T>(string type, string application)
        {
            var t = Utilities.GetTypeByName(type);
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(t, null);
        }

        internal override T Create<T>(Type type, ILogger logger)
        {
            if (type == null)
            {
                type = typeof(T);
            }
            
            return logger == null
                ? (T) Activator.CreateInstance(type, HttpClient)
                : (T) Activator.CreateInstance(type, HttpClient, logger);
        }
    }
}