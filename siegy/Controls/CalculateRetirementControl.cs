using siegy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace siegy.Controls
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

            int inputYear;
            var input = _view.WaitForInput().Trim();

            while (!"X".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                if (Int32.TryParse(input, out inputYear))
                {
                    _model.SetEndYear(inputYear);
                }
                input = _view.WaitForInput();
            }
        }
    }
}