using SiegyConsole.Interfaces;
using System;

namespace SiegyConsole.Controls
{
    internal class CalculateRetirementControl : IControl
    {
        private readonly IView _view;
        private readonly IModel _model;

        public string ExitCondition => "X";

        public CalculateRetirementControl(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _model.Attach(view);
            _view.SetModel(_model);
            _view.SetController(this);
        }

        public void Run(int startYear)
        {
            _model.SetEndYear(startYear);

            while (true)
            {
                var input = _view.WaitForInput().Trim();

                if (ExitCondition.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting program... Have a nice day!");
                    // Perform any necessary cleanup here
                    Environment.Exit(0); // This will close the console immediately
                }

                if (!int.TryParse(input, out int inputYear))
                {
                    continue;
                }
                _model.SetEndYear(inputYear);
            }
        }

        void IControl.Run(int startYear)
        {
            throw new NotImplementedException();
        }
    }
}
