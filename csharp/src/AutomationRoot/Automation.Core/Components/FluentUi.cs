using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public abstract class FluentUi : IFluent
    {
        private readonly IWebDriver _driver;
        private readonly ILogger _logger;

        protected FluentUi(IWebDriver driver) 
            : this(driver, new TraceLogger())
        {
        }
        
        protected FluentUi(IWebDriver driver, ILogger logger)
        {
            _driver = driver;
            _logger = logger;
        }
        
        public T ChangeContext<T>()
        {
            throw new System.NotImplementedException();
        }

        public T ChangeContext<T>(string application)
        {
            throw new System.NotImplementedException();
        }
    }
}