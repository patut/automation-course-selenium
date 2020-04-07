using System.Collections.Generic;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
            throw new System.NotImplementedException();
        }
    }
}