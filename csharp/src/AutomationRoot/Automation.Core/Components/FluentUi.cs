using System;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public class FluentUi : FluentBase
    {
        public FluentUi(string driverParams)
            : this(new WebDriverFactory(driverParams).Get())
        {
        }

        public FluentUi(DriverParams driverParams)
            : this(new WebDriverFactory(driverParams).Get())
        {
        }
        
        public FluentUi(WebDriverFactory factory)
            : this(factory.Get())
        {
        }

        protected FluentUi(IWebDriver driver)
            : this(driver, new TraceLogger())
        {
        }

        protected FluentUi(IWebDriver driver, ILogger logger)
            : base(logger)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null, logger);
        }

        public override T ChangeContext<T>(string type, string application)
        {
            throw new NotImplementedException();
        }

        public override T ChangeContext<T>(string application)
        {
            return ChangeContext<T>(application, Logger);
        }

        internal override T Create<T>(Type type, ILogger logger)
        {
            if (type == null)
            {
                type = typeof(T);
            }
            
            return logger == null
                ? (T) Activator.CreateInstance(type, Driver)
                : (T) Activator.CreateInstance(type, Driver, logger);
        }
    }
}