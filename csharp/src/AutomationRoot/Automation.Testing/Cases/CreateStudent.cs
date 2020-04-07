using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class CreateStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            var firstname = testParams["firstname"].ToString();
            var lastname = testParams["lastname"].ToString();
            
            // perform Test Case
            return new StudentsUi(Driver)
                .ChangeContext<StudentsUi>(testParams["application"].ToString())
                .Create()
                .FirstName(firstname)
                .LastName(lastname)
                .EnrollmentDate(DateTime.Now)
                .Create()
                .FindByName(firstname)
                .Students()
                .Any();
        }
    }
}