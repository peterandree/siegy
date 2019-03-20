using SiegyConsole.Controls;
using SiegyConsole.Models;
using SiegyConsole.Views;

namespace Siegy
{
    public static class CalculateRetirement
    {
        public static void Main() => Begin();

        private static void Begin()
        {
            var view = new CalculateRetirementConsoleView();
            var model = new CalculateRetirementModel();
            var control = new CalculateRetirementControl(view, model);
            control.Run(2040);
        }
    }
}