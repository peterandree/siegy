using SiegyFinances.FinancialObjects;

namespace SiegyFinances.FinancialData.Years
{
    internal class MonthlyStockQuotes2018 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2018()
        {
            var lastQuote = 100.5m; //change when new informations are known

            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent);

            this._DividendDay = 112.121m;
            this._February = 109.29m;
            this._March = 105.32m;
            this._April = 104.20m;
            this._May = lastQuote;
            this._June = lastQuote;
            this._July = lastQuote;
            this._August = 110.70m;
            this._September = 109.32m;
            this._October = 100.5m;
            this._November = lastQuote;
            this._December = lastQuote;
            this._January = lastQuote;
        }
    }
}