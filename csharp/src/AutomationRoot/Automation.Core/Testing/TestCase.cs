using System;
using System.Collections.Generic;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        // fields
        private IDictionary<string, object> _testParams;
        private int _attempts;
        private ILogger _logger;

        protected TestCase()
        {
            _testParams = new Dictionary<string, object>();
            _attempts = 1;
            _logger = new TraceLogger();
        }
        
        // components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            for (int i = 0; i < _attempts; i++)
            {
                Driver = Get();
                try
                {
                    Actual = AutomationTest(_testParams);
                    if (Actual)
                    {
                        break;
                    }

                    _logger.Debug($"[{GetType()?.FullName}] failed on attempt [{i + 1}]");
                }
                catch (AssertInconclusiveException e)
                {
                    _logger.Debug(e, e.Message);
                    break;
                }
                catch (NotImplementedException e)
                {
                    _logger.Debug(e, e.Message);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Debug(e, e.Message);
                }
                finally
                {
                    Driver.Dispose();
                    //Driver.Close();
                }
            }
            return this;
        }

        // properties
        public bool Actual { get; private set; }

        public IWebDriver Driver { get; private set; }

        // configuration
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            _testParams = testParams;
            return this;
        }

        public TestCase WithNumberOfAttempts(int attempts)
        {
            _attempts = attempts;
            return this;
        }

        public TestCase WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }
        
        //setup
        private IWebDriver Get()
        {
            // constants
            const string driver = "driver";
            
            //default
            var driverParams = new DriverParams() {Binaries = ".", Driver = "chrome"};
            
            // change driver if exists
            if (_testParams.ContainsKey(driver))
            {
                driverParams.Driver = $"{_testParams[driver]}";
            }

            // create web driver
            return new WebDriverFactory(driverParams).Get();
        }
    }
}