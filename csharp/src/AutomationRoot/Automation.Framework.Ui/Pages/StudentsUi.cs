using System.Collections.Generic;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Framework.Ui.Components;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUi : FluentUi, IStudents
    {
        public StudentsUi(IWebDriver driver) 
            : base(driver)
        {
        }

        public StudentsUi(IWebDriver driver, ILogger logger) 
            : base(driver, logger)
        {
        }

        public IStudents Next()
        {
            throw new System.NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new System.NotImplementedException();
        }

        public int Pages()
        {
            throw new System.NotImplementedException();
        }

        public int Page()
        {
            throw new System.NotImplementedException();
        }

        public T Menu<T>(string menuName)
        {
            throw new System.NotImplementedException();
        }

        public ICreateStudent Create()
        {
            throw new System.NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='SearchString']"))
                .SendKeys(name);
            Driver.SubmitForm(0);
            return this;
        }

        public IEnumerable<IStudent> Students()
        {
            return new StudentUi[0];
        }
    }
}