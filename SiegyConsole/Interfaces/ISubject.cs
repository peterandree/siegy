namespace SiegyConsole.Interfaces
{
    internal interface ISubject
    {
        void Attach(IObserver p_observer);
        void Detach(IObserver p_observer);
        void Notify();
    }
}
