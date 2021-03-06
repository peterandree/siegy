﻿using SiegyConsole.Interfaces;
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

            var input = _view.WaitForInput().Trim();

            while (!ExitCondition.Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(input, out int inputYear))
                {
                    _model.SetEndYear(inputYear);
                }
                input = _view.WaitForInput().Trim();
            }
        }

        void IControl.Run(int startYear)
        {
            throw new NotImplementedException();
        }
    }
}