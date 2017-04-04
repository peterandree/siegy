using Siegy.Interfaces;
using Siegy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Views
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

            var returns = _model.investmentReturns;

            Display.ConWriteLineFinancial("Gesamtinvestment: {0}", _model.investmentReturns.InvestedCapital);

            Display.ConWriteLineNumber("Anzahl der Aktien im Jahr {0}: {1}", returns.Endyear, returns.Ammount);

            Display.ConWriteLineFinancial("Wert einer Aktie im Jahr {0}: {1}", returns.Endyear, returns.StockValue);
            Display.ConWriteLineFinancial("Gesamtwert der Aktien im Jahr {0}: {1}", returns.Endyear, returns.Ammount * returns.StockValue);

            Display.ConWriteLineFinancial("Geschätze Dividende pro Aktie im Jahr {0}: {1}", returns.Endyear, returns.DivPerStock);

            Display.ConWriteLineFinancial("Geschätze Dividendenzahlungen im Jahr {0}: {1}", returns.Endyear, returns.Ammount * returns.DivPerStock);
        }

        public string WaitForInput()
        {
            Console.WriteLine("Enter a year to continue...");
            return Console.ReadLine();
        }
    }
}

  
