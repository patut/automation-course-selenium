using System.Collections.Generic;
using System.Linq;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var keyword = testParams["keyword"].ToString();
            
            // perform Test Case
            return new StudentsUi(Driver)
                .ChangeContext<StudentsUi>(testParams["application"].ToString())
                .FindByName(keyword)
                .Students()
                .All(s => s.FirstName() == keyword || s.LastName() == keyword);
        }
    }
}