using siegy.FinancialCalculations;
using siegy.FinancialObjects;
using Siegy.Factories;
using Siegy.FinancialObjects;
using Siegy.FinancialObjects;
using Siegy.Helpers;
using Siegy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.Models
{
    internal class CalculateRetirementModel : IModel
    {
        #region properties
        
        private InvestmentReturns  _investmentReturns = new InvestmentReturns();

        public InvestmentReturns investmentReturns =>  _investmentReturns;

        private int _endYear;

        //Observerproperties
        private readonly List<IObserver> _observers = new List<IObserver>();

        #endregion

        public void SetEndYear(int p_endyear)
        {
            _endYear = p_endyear;
            Calculate();
            Notify();
        }

        public void Calculate() => _investmentReturns = CalculateReturns.Calculate(_endYear);


        public void Attach(IObserver p_observer) => _observers.Add(p_observer);

        public void Detach(IObserver p_observer) => _observers.Remove(p_observer);

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}