using siegy.Interfaces;
using Siegy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.Views
{
    internal class CalculateRetirementView : IView
    {
        private IControl _controller;
        private IModel _model;

        public void SetController(IControl controller)
        {
            _controller = controller;
        }

        public void SetModel(IModel model)
        {
            _model = model;
        }

        public void Update()
        {
            Draw();
        }

        private void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Display.ConWriteLineFinancial("Gesamtinvestment: {0}", _model.InvestedCapital);

            Display.ConWriteLineNumber("Anzahl der Aktien im Jahr {0}: {1}", _model.Endyear, _model.Ammount);

            Display.ConWriteLineFinancial("Wert einer Aktie im Jahr {0}: {1}", _model.Endyear, _model.StockValue);
            Display.ConWriteLineFinancial("Gesamtwert der Aktien im Jahr {0}: {1}", _model.Endyear, _model.Ammount * _model.StockValue);

            Display.ConWriteLineFinancial("Geschätze Dividende pro Aktie im Jahr {0}: {1}", _model.Endyear, _model.DivPerStock);

            Display.ConWriteLineFinancial("Geschätze Dividendenzahlungen im Jahr {0}: {1}", _model.Endyear, _model.Ammount * _model.DivPerStock);
        }

        public string WaitForInput()
        {
            Console.WriteLine("Enter a year to continue...");
            return Console.ReadLine();
        }
    }
}