using SiegyFinances.Factories;
using SiegyFinances.FinancialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegyFinances.FinancialData.Years
{
    internal class MonthlyStockQuotes2017 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2017()
        {
            var lastQuote = 123.10m; //change when new informations are known

            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent);

            this._DividendDay = 117.85m;
            this._February = 121.35m;
            this._March = 123.10m;
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