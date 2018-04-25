using SiegyFinances.FinancialObjects;

namespace SiegyFinances.FinancialData.Years
{
    internal class MonthlyStockQuotes2018 : MonthlyStockQuotes
    {
        public MonthlyStockQuotes2018()
        {
            var lastQuote = 104.20m; //change when new informations are known

            lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent);

            this._DividendDay = 112.121m;
            this._February = 109.29m;
            this._March = 105.32m;
            this._April = 104.20m;
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