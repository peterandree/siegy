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
            // Ensure the console supports the euro symbol
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.White;

            var returns = _model.InvestmentReturns;
            var endyear = returns.Endyear;
            var totalValue = returns.amount * returns.StockValue;

            // Function to print a line with a color for the variable
            static void PrintColoredLine(ConsoleColor color, string literal, object variable)
            {
                Console.Write(literal);
                Console.ForegroundColor = color;
                Console.Write(variable);
                Console.ResetColor();  // Reset the console color after printing the variable
                Console.WriteLine();
            }

            // Calculate dividend yield
            decimal dividendYield = (returns.DivPerStock / returns.StockValue) * 100;

            // Use the function to print colored output
            PrintColoredLine(ConsoleColor.Yellow, "Total investment: ", $"{returns.InvestedCapital:F2} €");
            PrintColoredLine(ConsoleColor.Green, $"Number of shares in year {endyear}: ", $"{returns.amount:F2}");
            PrintColoredLine(ConsoleColor.DarkYellow, $"Value of one share in year {endyear}: ", $"{returns.StockValue:F2} €");
            PrintColoredLine(ConsoleColor.Blue, $"Total value of shares in year {endyear}: ", $"{totalValue:F2} €");
            PrintColoredLine(ConsoleColor.Magenta, $"Estimated dividend per share in year {endyear}: ", $"{returns.DivPerStock:F2} €");
            PrintColoredLine(ConsoleColor.Cyan, $"Dividend yield in year {endyear}: ", $"{dividendYield:F2}%");
            PrintColoredLine(ConsoleColor.DarkCyan, $"Estimated dividends payment in year {endyear}: ", $"{(returns.amount * returns.DivPerStock):F2} €");
            PrintColoredLine(ConsoleColor.Red, $"Total return in year {endyear}: ", $"{((totalValue - returns.InvestedCapital) * 100 / returns.InvestedCapital):F2}%");
        }

        public string WaitForInput()
        {
            Console.WriteLine($"Enter a year between 2012 and 2040 to continue or \"{Controller.ExitCondition}\" to abort calculation ");
            return Console.ReadLine();
        }
    }
}