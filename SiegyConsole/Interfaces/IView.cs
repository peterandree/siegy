namespace SiegyConsole.Interfaces
{
    internal interface IView : IObserver
    {
        void SetController(IControl controller);

        void SetModel(IModel model);

        //void Update();

        string WaitForInput(); //"Eventhandler"
    }
}