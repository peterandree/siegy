namespace SiegyConsole.Interfaces
{
    public interface IControl
    {
        void Run(int startYear);

        string ExitCondition { get; }
    }
}