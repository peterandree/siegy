using Siegy.Factories;
using Siegy.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siegy.FinancialData.Years
{
    internal class MonthlyStockQuotes2017 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2017()
        {
            var lastQuote = MonthlyStockQuotesFactory.Get(2016).January; //change when new informations are known

            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent);

            this._DividendDay = lastQuote;
            this._February = lastQuote;
            this._March = lastQuote;
            this._April = lastQuote;
            this._May = lastQuote;
            this._June = lastQuote;
            this._July = lastQuote;
            this._August = lastQuote;
            this._September = lastQuote;
            this._October = lastQuote;
            this._November = lastQuote;
            this._December = lastQuote;
            this._January = lastQuote;
        }
    }
}