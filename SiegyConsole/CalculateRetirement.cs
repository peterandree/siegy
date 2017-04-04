using SiegyConsole.Controls;
using SiegyConsole.Models;
using SiegyConsole.Views;
using SiegyConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Siegy
{
    public static class CalculateRetirement
    {
        public static void Main() => Begin();

        private static void Begin()
        {
            var view = new CalculateRetirementView();
            var model = new CalculateRetirementModel();
            var control = new CalculateRetirementControl(view, model);
            control.Run(2040);
        }
    }
}