using System;
using Automation.Api.Components;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi : FluentUi, IStudent
    {
        public StudentUi(IWebDriver driver) 
            : this(driver, new TraceLogger())
        {
        }

        public StudentUi(IWebDriver driver, ILogger logger) 
            : base(driver, logger)
        {
        }

        // Data
        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }
        
        // Actions
        
        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object Details()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }
    }
}