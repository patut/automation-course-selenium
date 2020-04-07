using System.Collections.Generic;
using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface IStudents
    {
        IStudents FindByName(string name);
        
        IEnumerable<IStudent> Students();
    }
}