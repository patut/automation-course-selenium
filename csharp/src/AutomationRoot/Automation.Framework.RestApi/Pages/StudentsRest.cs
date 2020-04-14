using System.Collections.Generic;
using System.Net.Http;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentsRest : FluentRestApi, IStudents
    {
        public StudentsRest(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public StudentsRest(HttpClient httpClient, ILogger logger) 
            : base(httpClient, logger)
        {
        }

        public IStudents Next()
        {
            throw new System.NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new System.NotImplementedException();
        }

        public int Pages()
        {
            throw new System.NotImplementedException();
        }

        public int Page()
        {
            throw new System.NotImplementedException();
        }

        public T Menu<T>(string menuName)
        {
            throw new System.NotImplementedException();
        }

        public ICreateStudent Create()
        {
            throw new System.NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
            throw new System.NotImplementedException();
        }
    }
}