using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Framework.RestApi.Components;
using Newtonsoft.Json.Linq;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentsRest : FluentRest, IStudents
    {
        public StudentsRest(HttpClient httpClient) 
            : this(httpClient, new TraceLogger())
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
            var response = HttpClient.GetAsync("/api/Students/")
                .GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                return new IStudent[0];
            }

            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JToken.Parse(responseBody).Select(i => new StudentRestApi(HttpClient, i));
        }
    }
    
}