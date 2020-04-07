using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IStudentDetails, ICreate<IStudents>, IBack<IStudents>
    {
    }
}