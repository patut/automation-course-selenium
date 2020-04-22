using System;
using System.Net.Http;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace Automation.Framework.RestApi.Components
{
    public class StudentRestApi : FluentRestApi, IStudent
    {
        private readonly JToken _dataRow;
        private string _firstName;
        private string _lastName;
        private DateTime _entollmentDate;
        
        public StudentRestApi(HttpClient httpClient, JToken dataRow) : this(httpClient, new TraceLogger())
        {
            _dataRow = dataRow;
            Build(dataRow);
        }

        public StudentRestApi(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public string FirstName()
        {
            return _firstName;
        }

        public string LastName()
        {
            return _lastName;
        }

        public DateTime EnrollmentDate()
        {
            return _entollmentDate;
        }

        public IStudentDetails Details()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }
        
        private void Build(JToken dataRow)
        {
            _firstName = dataRow["firstMidName"].ToString();
            _lastName = dataRow["lastName"].ToString();
            _entollmentDate = DateTime.Parse(dataRow["enrollmentDate"].ToString());
        }
    }
}