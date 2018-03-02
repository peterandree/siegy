using SiegyFinances.FinancialData;
using SiegyFinances.FinancialData.Years;
using SiegyFinances.Interfaces;

namespace SiegyFinances.Factories
{
    public static class MonthlyStockQuotesFactory
    {
        public static IMonthlyStockQuotes Get(int p_year)
        {
            const int lastAtLeastPartiallyKnownYear = 2018;

            switch (p_year)
            {
                case 2011:
                    {
                        return new MonthlyStockQuotes2011();
                    }
                case 2012:
                    {
                        return new MonthlyStockQuotes2012();
                    }
                case 2013:
                    {
                        return new MonthlyStockQuotes2013();
                    }
                case 2014:
                    {
                        return new MonthlyStockQuotes2014();
                    }
                case 2015:
                    {
                        return new MonthlyStockQuotes2015();
                    }
                case 2016:
                    {
                        return new MonthlyStockQuotes2016();
                    }
                case 2017:
                    {
                        return new MonthlyStockQuotes2017();
                    }
                case 2018:
                    {
                        return new MonthlyStockQuotes2018();
                    }
                default:
                    {
                        var lastQuote = Get(lastAtLeastPartiallyKnownYear).January;
                        lastQuote += lastQuote * (SpeculativeData.ExpectedYearlyStockValueRaiseInPercent * (p_year - lastAtLeastPartiallyKnownYear));

                        return new MonthlyStockQuotesFuture(lastQuote);
                    }
            }
        }
    }
}