using SiegyFinances.FinancialData;
using SiegyFinances.FinancialObjects;
using SiegyFinances.Interfaces;
using static SiegyFinances.Enums.MonthlyStockQuotes;

namespace SiegyFinances.Factories
{
    public static class MonthlyStockQuotesFactory
    {
        public static IMonthlyStockQuotes Get(int p_year)
        {
            const int firstAtLeastPartiallyKnownYear = 2011;
            const int lastAtLeastPartiallyKnownYear = 2019; //todo pk: determine dynamically the last known year

            if (p_year < firstAtLeastPartiallyKnownYear)
            {
                throw new System.ArgumentException($"Year '{p_year}' is out of range");
            }
            else if (p_year <= lastAtLeastPartiallyKnownYear)
            {
                var quotes = new MonthlyStockQuotes(Helpers.FileHelpers.FillWithQuotes(p_year));

                var lastKnownQuote = 0.0m;

                for (int i = 0; i < quotes.StockRatesListed().Count; i++)//don't use the enums here to preserve the upward logic of the months
                {
                    if (quotes.StockRatesListed()[i] > 0m)
                    {
                        lastKnownQuote = quotes.StockRatesListed()[i];
                    }
                    else
                    {
                        if (lastKnownQuote == 0)
                        {
                            lastKnownQuote = p_year == firstAtLeastPartiallyKnownYear ? 0.0m : Get(p_year - 1).January; // not dividend day because of ex dividend effect
                        }
                        quotes.UpdateStockRatedListed(i, lastKnownQuote);
                    }
                }
                if (quotes.DividendDay <= 0)
                {
                    quotes.UpdateStockRatedListed(BuyEvent.DividendDay, lastKnownQuote);
                }
                return quotes;
            }
            else
            {
                var lastQuote = Get(lastAtLeastPartiallyKnownYear).January; // not dividend day because of ex dividend effect
                lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * (p_year - lastAtLeastPartiallyKnownYear));

                return new MonthlyStockQuotes(lastQuote);
            }
        }
    }
}