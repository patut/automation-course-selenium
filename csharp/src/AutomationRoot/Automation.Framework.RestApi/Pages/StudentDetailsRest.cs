using System;
using System.Net.Http;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentDetailsRest : FluentRest, IStudentDetails
    {
        public StudentDetailsRest(HttpClient httpClient) : base(httpClient)
        {
        }

        public StudentDetailsRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
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

        public IEnrollment[] Enrollments()
        {
            throw new NotImplementedException();
        }
    }
}