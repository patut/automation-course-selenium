using System;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public abstract class FluentUi : FluentBase
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
            return Create<T>(logger);
        }

        public override T ChangeContext<T>(string application)
        {
            return ChangeContext<T>(application, Logger);
        }

        internal override T Create<T>(ILogger logger)
        {
            return logger == null
                ? (T) Activator.CreateInstance(typeof(T), Driver)
                : (T) Activator.CreateInstance(typeof(T), Driver, logger);
        }
    }
}