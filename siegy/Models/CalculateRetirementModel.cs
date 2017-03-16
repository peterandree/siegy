using siegy.FinancialObjects;
using siegy.Interfaces;
using Siegy.Factories;
using Siegy.FinancialObjects;
using Siegy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siegy.Models
{
    internal class CalculateRetirementModel : IModel
    {
        #region properties
        public decimal Ammount => _ammount;

        public int Endyear => _endYear;

        public decimal DivPerStock => _divPerStock;

        public decimal StockValue => _stockValue;

        public decimal InvestedCapital => _investedCapital;

        //   public     List<decimal> averageReturnOnInvest { get;  }

        private int _endYear;
        private decimal _ammount;
        private decimal _divPerStock;
        private decimal _stockValue;
        private decimal _investedCapital;

        //Observerproperties
        private List<IObserver> _observers = new List<IObserver>();

        #endregion

        public void SetEndYear(int p_endyear)
        {
            _endYear = p_endyear;
            Calculate();
            Notify();
        }


        public void Calculate()
        {
            var averageReturnOnInvest = new List<decimal>();

            _ammount = 0m;
            _investedCapital = 0m;
            foreach (InvestmentYear currentYear in AllPossibleYearsForMe.AllYears())
            {
                if (currentYear.Year <= _endYear)
                {
                    _ammount += currentYear.AccumulatedStocks(_endYear);
                    _investedCapital += currentYear.InvestedCapital();
                }
            }

            _stockValue = Siegy.Factories.MonthlyStockQuotesFactory.Get(_endYear).DividendDay;
            _divPerStock = Financial.GetDividend(_endYear);
        }

        public void Attach(IObserver p_observer)
        {
            _observers.Add(p_observer);
        }

        public void Detach(IObserver p_observer)
        {
            _observers.Remove(p_observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}