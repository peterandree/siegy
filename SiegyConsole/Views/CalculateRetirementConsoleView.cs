using SiegyConsole.Helpers;
using SiegyConsole.Interfaces;
using System;

namespace SiegyConsole.Views
{
    internal class CalculateRetirementConsoleView : IView
    {
        private IModel _model;

        internal IControl Controller { get; set; }

        public void SetController(IControl controller) => Controller = controller;

        public void SetModel(IModel model) => _model = model;

        public void Update() => Draw();

        private void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;

            var returns = _model.InvestmentReturns;
            var endyear = returns.Endyear;
            var totalValue = returns.Ammount * returns.StockValue;

            Display.ConWriteLineFinancial("Total investment: {0}", returns.InvestedCapital);

            Display.ConWriteLineNumber("Number of shares in year {0}: {1}", endyear, returns.Ammount);

            Display.ConWriteLineFinancial("Value of one share in year {0}: {1}", endyear, returns.StockValue);
            Display.ConWriteLineFinancial("Total value of shares in year {0}: {1}", endyear, totalValue);

            Display.ConWriteLineFinancial("Estimated dividend per share in year {0}: {1}", endyear, returns.DivPerStock);

            Display.ConWriteLineFinancial("Estimated dividends payment in year {0}: {1}", endyear, returns.Ammount * returns.DivPerStock);

            Display.ConWriteLineNumber("Total return in year {0}: {1}%", endyear, (totalValue - returns.InvestedCapital) * 100 / returns.InvestedCapital);
        }

        public string WaitForInput()
        {
            Console.WriteLine($"Enter a year between 2012 and 2040 to continue or \"{Controller.ExitCondition}\" to abort calculation ");
            return Console.ReadLine();
        }
    }
}