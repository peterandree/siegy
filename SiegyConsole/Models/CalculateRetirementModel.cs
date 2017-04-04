using SiegyFinances.FinancialCalculations;
using SiegyFinances.FinancialObjects;
using SiegyConsole.Interfaces;
using System.Collections.Generic;

namespace SiegyConsole.Models
{
    internal class CalculateRetirementModel : IModel
    {
        #region properties

        private InvestmentReturns _investmentReturns = new InvestmentReturns();

        public InvestmentReturns investmentReturns => _investmentReturns;

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