using System.Collections.Generic;
using System.Linq;
using Automation.Api.Pages;
using Automation.Core.Testing;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            // creating driver for this case
            var driver = new WebDriverFactory(new DriverParams() {Binaries = ".", Driver = "chrome"})
                .Get();
            
            // perform Test Case
            return new StudentsUi(driver)
                .ChangeContext<StudentsUi>("https://gravitymvctestapplication.azurewebsites.net/Student")
                .FindByName("Alexander")
                .Students()
                .All(s => s.FirstName() == "Alexander" || s.LastName() == "Alexander");
        }
    }
}