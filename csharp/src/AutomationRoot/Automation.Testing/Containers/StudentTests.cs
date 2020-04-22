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
        [DataRow(@"{
                    'driver': 'chrome', 
                    'keyword':'Alexander', 
                    'application':'https://gravitymvctestapplication.azurewebsites.net/Student',
                    'fluent':'Automation.Core.Components.FluentUi',
                    'students':'Automation.Framework.Ui.Pages.StudentsUi'
                    }")]
        [DataRow(@"{
                    'driver': 'HTTP', 
                    'keyword':'Alexander', 
                    'application':'https://gravitymvctestapplication.azurewebsites.net/Student',
                    'fluent':'Automation.Core.Components.FluentRest',
                    'students':'Automation.Framework.RestApi.Pages.StudentsRest'
                    }")]
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
//        [DataRow(@"{
//                    'driver': 'chrome', 
//                    'keyword':'Alexander', 
//                    'application':'https://gravitymvctestapplication.azurewebsites.net/Student',
//                    'fluent':'Automation.Core.Components.FluentUi',
//                    'students':'Automation.Framework.Ui.Pages.StudentsUi'
//                    }")]
        [DataRow(@"{
                    'driver': 'HTTP', 
                    'keyword':'Alexander', 
                    'application':'https://gravitymvctestapplication.azurewebsites.net/Student',
                    'fluent':'Automation.Core.Components.FluentRest',
                    'students':'Automation.Framework.RestApi.Pages.StudentsRest'
                    }")]
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
    }
}