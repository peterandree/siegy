using SiegyFinances.FinancialData;
using SiegyFinances.FinancialObjects;
using SiegyFinances.Interfaces;
using static SiegyFinances.Enums.MonthlyStockQuotes;

namespace SiegyFinances.Factories
{
    public class MonthlyStockQuotesFactory
    {
        private readonly int _firstAtLeastPartiallyKnownYear;
        private readonly int _lastAtLeastPartiallyKnownYear;

        private MonthlyStockQuotesFactory()
        {
        }

        public MonthlyStockQuotesFactory(int p_firstAtLeastPartiallyKnownYear)
        {
            _firstAtLeastPartiallyKnownYear = p_firstAtLeastPartiallyKnownYear;
            _lastAtLeastPartiallyKnownYear = FindLastKnownYear(p_firstAtLeastPartiallyKnownYear);
        }
        public IMonthlyStockQuotes Get(int p_year)
        {
            if (p_year < _firstAtLeastPartiallyKnownYear)
            {
                throw new System.ArgumentException($"Year '{p_year}' is out of range");
            }
            else if (p_year <= _lastAtLeastPartiallyKnownYear)
            {
                var quotes = new MonthlyStockQuotes(Helpers.FileHelpers.FillWithQuotes(p_year));

                var lastKnownQuote = 0.0m;

                for (int i = 0; i < quotes.StockRatesListed().Count; i++) //don't use the enums here to preserve the upward logic of the months
                {
                    if (quotes.StockRatesListed()[i] > 0m)
                    {
                        lastKnownQuote = quotes.StockRatesListed()[i];
                    }
                    else
                    {
                        if (lastKnownQuote == 0)
                        {
                            lastKnownQuote = p_year == _firstAtLeastPartiallyKnownYear ? 0.0m : Get(p_year - 1).January; // not dividend day because of ex dividend effect
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
                var lastQuote = Get(_lastAtLeastPartiallyKnownYear).January; // not dividend day because of ex dividend effect
                lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * (p_year - _lastAtLeastPartiallyKnownYear));

                return new MonthlyStockQuotes(lastQuote);
            }
        }

        private static int FindLastKnownYear(int p_year)
        {
            var found = false;
            do
            {
                var quotes = new MonthlyStockQuotes(Helpers.FileHelpers.FillWithQuotes(p_year));
                if (quotes.February > 0)
                {
                    p_year++;
                }
                else
                {
                    found = true;
                    p_year--;
                }
            } while (!found);
            return p_year;
        }
    }
}