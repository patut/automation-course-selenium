using System;
using System.Net.Http;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;

namespace Automation.Framework.RestApi.Components
{
    public class StudentRestApi : FluentRestApi, IStudent
    {
        public StudentRestApi(HttpClient httpClient) : base(httpClient)
        {
        }

        public StudentRestApi(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
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
    }
}