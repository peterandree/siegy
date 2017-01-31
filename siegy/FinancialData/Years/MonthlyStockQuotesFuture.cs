using Siegy.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.FinancialData.Years
{
    internal class MonthlyStockQuotesFuture : MonthlyStockQuotes
    {
        private MonthlyStockQuotesFuture()
        {
        }

        public MonthlyStockQuotesFuture(decimal p_guess)
        {
            this._DividendDay = p_guess;
            this._February = p_guess;
            this._March = p_guess;
            this._April = p_guess;
            this._May = p_guess;
            this._June = p_guess;
            this._July = p_guess;
            this._August = p_guess;
            this._September = p_guess;
            this._October = p_guess;
            this._November = p_guess;
            this._December = p_guess;
            this._January = p_guess;
        }
    }
}