using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
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
                SetUp();
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
                    Driver?.Dispose();
                    HttpClient?.Dispose();
                    //Driver.Close();
                }
            }
            return this;
        }

        // properties
        public bool Actual { get; private set; }

        public IWebDriver Driver { get; private set; }
        
        public HttpClient HttpClient { get; private set; }

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
        
        // factory
        public IFluent CreateFluentApi(string type)
        {
            // extract type
            var t = Utilities.GetTypeByName(type);
            
            // extract constructors
            var ctr = t.GetConstructors();
            
            // setup conditions
            var isFluent = typeof(FluentBase).IsAssignableFrom(t);
            var isRest = isFluent && ctr.Any(i => i.GetParameters()
                             .Any(p => p.ParameterType == typeof(HttpClient)));
            var isFront = isFluent && ctr.Any(i => i.GetParameters()
                             .Any(p => p.ParameterType == typeof(IWebDriver)));
            
            // factoring
            if (isRest)
                return (IFluent) Activator.CreateInstance(t, HttpClient, _logger);

            if (isFront)
                return (IFluent) Activator.CreateInstance(t, Driver, _logger);

            throw new NotFoundException($"Implementation of {type} was not found.");
        }

        //setup
        private void SetUp()
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
            else
            {
                _testParams[driver] = string.Empty;
            }
            
            if ($"{_testParams[driver]}".Equals("HTTP", StringComparison.OrdinalIgnoreCase))
            {
                HttpClient = new HttpClient();
                return;
            }

            // create web driver
            Driver = new WebDriverFactory(driverParams).Get();
        }
    }
}