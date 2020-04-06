namespace Automation.Core.Components
{
    public interface IFluent
    {
        T ChangeContext<T>();
        T ChangeContext<T>(string application);
    }
}