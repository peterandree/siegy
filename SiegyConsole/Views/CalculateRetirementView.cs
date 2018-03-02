﻿using SiegyConsole.Interfaces;
using SiegyConsole.Helpers;
using SiegyFinances.FinancialObjects;
using System;

namespace SiegyConsole.Views
{
    internal class CalculateRetirementView : IView
            {
        private IControl _controller;
        private IModel _model;

        public void SetController(IControl controller) => _controller = controller;

        public void SetModel(IModel model) => _model = model;

        public void Update() => Draw();

        private void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;

            InvestmentReturns returns   = _model.investmentReturns;

            Display.ConWriteLineFinancial("Total investment: {0}", returns.InvestedCapital);

            Display.ConWriteLineNumber("Number of shares in year {0}: {1}", returns.Endyear, returns.Ammount);

            Display.ConWriteLineFinancial("Value of a shares in year {0}: {1}", returns.Endyear, returns.StockValue);
            Display.ConWriteLineFinancial("Total value of shares in year {0}: {1}", returns.Endyear, returns.Ammount * returns.StockValue);

            Display.ConWriteLineFinancial("Estimated dividend per share in year {0}: {1}", returns.Endyear, returns.DivPerStock);

            Display.ConWriteLineFinancial("Estimated dividends payment in year {0}: {1}", returns.Endyear, returns.Ammount * returns.DivPerStock);
        }

        public string WaitForInput()
        {
            Console.WriteLine("Enter a year between 2012 and 2040 to continue or \"x\" to abort calculation ");
            return Console.ReadLine();
        }
    }
}

  