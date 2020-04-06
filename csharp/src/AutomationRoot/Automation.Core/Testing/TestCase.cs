using System.Collections.Generic;
using Automation.Core.Logging;

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
            Actual = AutomationTest(_testParams);
            return this;
        }

        // properties
        public bool Actual { get; private set; }

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
    }
}