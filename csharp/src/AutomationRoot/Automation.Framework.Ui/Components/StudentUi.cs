using System;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi : FluentUi, IStudent
    {
        private readonly IWebElement _dataRow;
        private string _firstName;
        private string _lastName;
        private DateTime _entollmentDate;
        
        public StudentUi(IWebDriver driver, IWebElement dataRow) 
            : this(driver, new TraceLogger())
        {
            _dataRow = dataRow;
            Build(dataRow);
        }

        private StudentUi(IWebDriver driver, ILogger logger) 
            : base(driver, logger)
        {
        }

        // Data
        public string FirstName()
        {
            return _firstName;
        }

        public string LastName()
        {
            return _lastName;
        }

        public DateTime EnrollmentDate()
        {
            return _entollmentDate;
        }
        
        // Actions
        
        public object Edit()
        {
            throw new NotImplementedException();
        }

        public IStudentDetails Details()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }
        
        // processing
        private void Build(IWebElement dataRow)
        {
            _firstName = dataRow.FindElement(By.XPath("./td[2]")).Text.Trim();
            _lastName = dataRow.FindElement(By.XPath("./td[1]")).Text.Trim();
            
            // parse date
            var dateString = dataRow.FindElement(By.XPath("./td[3]")).Text.Trim();
            DateTime.TryParse(dateString, out _entollmentDate);
        }
    }
}