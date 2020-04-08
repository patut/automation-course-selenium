using System;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Pages
{
    public class CreateStudentUi : FluentUi, ICreateStudent
    {
        public CreateStudentUi(IWebDriver driver) : base(driver)
        {
        }

        public CreateStudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

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

        public IStudents Create()
        {
            Driver.GetEnabledElement(By.XPath("//input[@type='submit']")).Click();
            return new StudentsUi(Driver);
        }

        public IStudents BackToList()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='FirstMidName']")).SendKeys(firstName);
            return this;
        }

        public ICreateStudent LastName(string lastName)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='LastName']")).SendKeys(lastName);
            return this;
        }

        public ICreateStudent EnrollmentDate(DateTime enrollmentDate)
        {
            var script =
                $"document.getElementById('EnrollmentDate').setAttribute('value', '{enrollmentDate:yyyy-MM-dd}');";
            ((IJavaScriptExecutor) Driver).ExecuteScript(script);
            return this;
        }
    }
}