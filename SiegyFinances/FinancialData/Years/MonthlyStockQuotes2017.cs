using SiegyFinances.FinancialObjects;

namespace SiegyFinances.FinancialData.Years
{
    internal class MonthlyStockQuotes2017 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2017()
        {
            var lastQuote = 110.20m; //change when new informations are known

            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent);
            
            this._DividendDay = 117.85m;
            this._February = 121.35m;
            this._March = 123.10m;
            this._April = 124.95m;
            this._May = 130.05m;
            this._June = 125.70m;
            this._July = 120.30m;
            this._August = 110.20m;
            this._September = lastQuote;
            this._October = lastQuote;
            this._November = lastQuote;
            this._December = lastQuote;
            this._January = lastQuote;
        }
    }
}