using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class StudentDetails : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var keyword = testParams["keyword"].ToString();
            
            // perform Test Case
            var student = new StudentsUi(Driver)
                .ChangeContext<StudentsUi>(testParams["application"].ToString())
                .FindByName(keyword)
                .Students()
                .First()
            
            // extract expected result
            var expected = student.FirstName();
            
            // assert
            return student.Details().FirstName().Equals(expected, StringComparison.OrdinalIgnoreCase)
        }
    }
}