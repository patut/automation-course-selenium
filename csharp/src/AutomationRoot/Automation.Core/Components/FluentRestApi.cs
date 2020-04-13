using System.Net.Http;
using Automation.Core.Logging;

namespace Automation.Core.Components
{
    public class FluentRestApi : IFluent
    {
        public FluentRestApi(HttpClient httpClient) 
            : this(httpClient, new TraceLogger())
        {
        }
        
        public FluentRestApi(HttpClient httpClient, ILogger logger)
        {
            HttpClient = httpClient;
            Logger = logger;
        }

        public HttpClient HttpClient { get; }
        
        public ILogger Logger { get; }
        
        public T ChangeContext<T>()
        {
            throw new System.NotImplementedException();
        }

        public T ChangeContext<T>(ILogger logger)
        {
            throw new System.NotImplementedException();
        }

        public T ChangeContext<T>(string application)
        {
            throw new System.NotImplementedException();
        }

        public T ChangeContext<T>(string application, ILogger logger)
        {
            throw new System.NotImplementedException();
        }
    }
}