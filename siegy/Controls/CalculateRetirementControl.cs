using Siegy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siegy.Controls
{
    internal class CalculateRetirementControl : IControl
    {
        private IView _view;
        private IModel _model;

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

            while (!"X".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(input,  out int inputYear))
                {
                    _model.SetEndYear(inputYear);
                }
                input = _view.WaitForInput();
            }
        }
    }
}