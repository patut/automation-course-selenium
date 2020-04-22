using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Automation.Core.Components;
using Automation.Framework.RestApi.Pages;
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
        
        [DataTestMethod]
        [DataRow(@"{'driver': 'chrome', 'firstname':'csharp', 'lastname':'student', 'application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void CreateStudentTest(string testParams)
        {
            // generate test params
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);
            
            // execute with parameters
            var actual = new CreateStudent()
                .WithTestParams(parameters)
                .Execute().Actual;
            
            // assert result
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(
            @"{'driver': 'chrome', 'keyword':'Alexander', 'application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void StudentDetailsTest(string testParams)
        {
            // generate test params
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);
            
            // execute with parameters
            var actual = new StudentDetails()
                .WithTestParams(parameters)
                .Execute().Actual;
            
            // assert result
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TempTest()
        {
            var studentsTest = new FluentRestApi(new HttpClient())
                .ChangeContext<StudentsRest>("https://gravitymvctestapplication.azurewebsites.net")
                .Students();
            
        }
    }
}