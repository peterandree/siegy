using SiegyFinances.FinancialData;
using SiegyFinances.FinancialObjects;
using SiegyFinances.Interfaces;

namespace SiegyFinances.Factories
{
    public static class MonthlyStockQuotesFactory
    {
        public static IMonthlyStockQuotes Get(int p_year)
        {
            const int firstAtLeastPartiallyKnownYear = 2011;
            const int lastAtLeastPartiallyKnownYear = 2018; //todo pk: determine dynamically the last known year

            if (p_year < firstAtLeastPartiallyKnownYear)
            {
                throw new System.ArgumentException($"Year '{p_year}' is out of range");
            }
            else if (p_year <= lastAtLeastPartiallyKnownYear)
            {
                var quotes = new MonthlyStockQuotes(Helpers.FileHelpers.FillWithQuotes(p_year));

                var lastKnownQuote = 0m;

                for (int i = 0; i < quotes.StockRatesListed().Count; i++)
                {
                    if (quotes.StockRatesListed()[i] > 0m)
                    {
                        lastKnownQuote = quotes.StockRatesListed()[i];
                    }
                    else
                    {
                        quotes.UpdateStockRatedListed(i, lastKnownQuote);
                    }
                }
                return quotes;
            }
            else
            {
                var lastQuote = Get(lastAtLeastPartiallyKnownYear).January;
                lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * (p_year - lastAtLeastPartiallyKnownYear));

                return new MonthlyStockQuotes(lastQuote);
            }
        }
    }
}