using System;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public abstract class FluentUi : IFluent
    {
        protected FluentUi(IWebDriver driver) 
            : this(driver, new TraceLogger())
        {
        }
        
        protected FluentUi(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }

        public IWebDriver Driver { get; }
        
        public ILogger Logger { get; }

        public T ChangeContext<T>()
        {
            var instance = Create<T>(null);
            Logger.Debug($"Instance of [{GetType()?.FullName}] created");
            return instance;
        }
        
        public T ChangeContext<T>(ILogger logger)
        {
            return Create<T>(logger);
        }
        
        public T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger); 
        }

        public T ChangeContext<T>(string application)
        {
            return ChangeContext<T>(application, Logger);
        }

        private T Create<T>(ILogger logger)
        {
            return logger == null
                ? (T) Activator.CreateInstance(typeof(T), Driver)
                : (T) Activator.CreateInstance(typeof(T), Driver, logger);
        }
    }
}