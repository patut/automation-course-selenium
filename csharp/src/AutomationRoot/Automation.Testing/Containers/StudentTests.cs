using System.Collections;
using System.Collections.Generic;
using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [DataTestMethod]
        [DataRow(@"{'driver': 'chrome', 'keyword':'Alexander', 'application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void SearchStudentUiTest(string testParams)
        {
            // generate test params
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);
            
            // execute with parameters
            var actual = new SearchStudents()
                .WithTestParams(parameters)
                .Execute().Actual;
            
            // assert result
            Assert.IsTrue(actual);
        }
    }
}