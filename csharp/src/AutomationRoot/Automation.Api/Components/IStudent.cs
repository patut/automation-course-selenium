using System;

namespace Automation.Api.Components
{
    public interface IStudent
    {
        string FirstName();
        
        string LastName();
        
        DateTime EnrollmentDate();
        
        object Edit();
        
        object Details();
        
        object Delete();
    }
}