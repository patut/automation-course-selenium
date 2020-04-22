using System.Collections.Generic;
using System.Linq;
using Automation.Api.Pages;
using Automation.Core.Testing;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var keyword = testParams["keyword"].ToString();
            var fluent = testParams["fluent"].ToString();
            var students = testParams["students"].ToString();
            
            // perform Test Case
            return CreateFluentApi(fluent)
                .ChangeContext<IStudents>(students, testParams["application"].ToString())
                .FindByName(keyword)
                .Students()
                .All(s => s.FirstName() == keyword || s.LastName() == keyword);
        }
    }
}